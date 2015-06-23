using UnityEngine;
using System.Collections;

public class Monstcheckhit : MonoBehaviour {

	// Use this for initialization

	public playerStateLinster playerstate;
	public Transform   player;
	public Transform axe_inGround;
	public Transform hammer_inGround;
	public AxeCollider axe_collider;
	public AxeCollider hammer_collider;
	public RolePropertyItem rolePropertyItem;
	private  Animator _animator;
	private AnimatorStateInfo _animatorinfo;

	public enum State{idle,walk,attacking,hitted,depth};
	public State curState =State.idle;
	void Start () {
		_animator = transform.GetComponent<Animator> ();
		axe_collider = axe_inGround.GetComponent<AxeCollider> ();
		hammer_collider = hammer_inGround.GetComponent<AxeCollider> ();
	}
	
	// Update is called once per frame
	void Update () {

		if (curState == State.depth) {
			return ;
		}
	
		//StartCoroutine (attackPer2second ());
		if(curState!=State.attacking && curState!=State.hitted&& Vector3.Distance (transform.position, player.position) < 0.3)
		{
			_animator.SetBool("idle2attack",true);
			_animator.SetBool("idle2walk",false);
			curState =State.attacking;
				
				player.animation["hit"].speed=(float)0.5;
			player.animation.CrossFade("hit");
				playerstate .xueDownRandom();


		}

		_animatorinfo = _animator.GetCurrentAnimatorStateInfo (0);
		if (!_animator.GetBool("idle2attack") &&!_animator.GetBool("idle2gethit")  &&_animatorinfo.IsName ("Base Layer.idle")) {
			curState =State.idle;
		}
		if ( curState !=State.hitted&&playerstate.ani_stat == playerStateLinster.enum_ani_state.Attacking1) {

			if(Vector3.Distance(player.position,transform.position)<(float)0.3 ||Vector3.Distance(player.position,transform.position)<1&&Vector3.Angle(player.transform.forward,transform.position-player.transform.position)<30)
			{
				_animator.SetBool("idle2gethit",true);
				_animator.SetBool("walk2gethit",true);
				curState =State.hitted;
				Debug.Log("getigt");
				rolePropertyItem.subXue();
			}
		}
		//if ( curState!=State.attacking&&playerstate.ani_stat == playerStateLinster.enum_ani_state.Idle||playerstate.ani_stat == playerStateLinster.enum_ani_state.NoAni) {
		//	curState =State.idle;
		//	Debug.Log("..........");
		//}

		if (rolePropertyItem.getCurXue() <= 0) {
			curState =State.depth;
			BossAnimation.smallMonsterdie++;
			StartCoroutine( WaitFordepthPlayOver());
		}

	}

	void OnTriggerEnter(Collider collider)
	{

		Debug.Log ("collider name "+collider.name);
	}

	IEnumerator WaitFordepthPlayOver()
	{
		//Debug.Log(Time.time);
	
		yield return new WaitForSeconds(3);
		Debug.Log("wait for 3 second");
		this.gameObject.SetActive (false);
		rolePropertyItem.setunvisible ();
		//Destroy (this.gameObject);
		//playerstate.setAniState((int)playerStateLinster.enum_ani_state.NoAni);
	}

	IEnumerator attackPer2second()
	{
		yield return new WaitForSeconds (5);

		if (curState!=State.attacking && curState!=State.hitted&& Vector3.Distance (transform.position, player.position) < 0.3) {
			_animator.SetBool("idle2attack",true);
			_animator.SetBool("idle2walk",false);
			curState =State.attacking;
			yield return new WaitForSeconds(1);
			if(Vector3.Distance (transform.position, player.position) < 0.3)
			{
				Debug.Log("monster hit");
				player.animation["hit"].speed=(float)0.5;
				player.animation.CrossFade("hit");
				playerstate .xueDownRandom();
			}
		}
	}


}
