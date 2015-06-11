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

	private  Animator _animator;
	private AnimatorStateInfo _animatorinfo;

	public enum State{idle,walk,attacking,hitted};
	public State curState =State.idle;
	void Start () {
		_animator = transform.GetComponent<Animator> ();
		axe_collider = axe_inGround.GetComponent<AxeCollider> ();
		hammer_collider = hammer_inGround.GetComponent<AxeCollider> ();
	}
	
	// Update is called once per frame
	void Update () {

		_animatorinfo = _animator.GetCurrentAnimatorStateInfo (0);

		if ( curState !=State.hitted&&playerstate.ani_stat == playerStateLinster.enum_ani_state.Attacking1) {

			if(Vector3.Distance(player.position,transform.position)<(float)0.3 ||Vector3.Distance(player.position,transform.position)<1&&Vector3.Angle(player.transform.forward,transform.position-player.transform.position)<30)
			{
				_animator.SetBool("idle2gethit",true);
				_animator.SetBool("walk2gethit",true);
				curState =State.hitted;
				Debug.Log("getigt");

			}
		}
		if (playerstate.ani_stat == playerStateLinster.enum_ani_state.Idle||playerstate.ani_stat == playerStateLinster.enum_ani_state.NoAni) {
			curState =State.idle;
		}

	}

	void OnTriggerEnter(Collider collider)
	{

		Debug.Log ("collider name "+collider.name);
	}


}
