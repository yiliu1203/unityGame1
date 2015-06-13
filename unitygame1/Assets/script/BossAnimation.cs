using UnityEngine;
using System.Collections;

public class BossAnimation : MonoBehaviour {

	public Transform player;
	public playerStateLinster playerstate;
	public enum  BossState {idle=0,walk,attack,gethit,noani}
	public BossState bossstate=BossState.noani;
	private string[] aniName={"idle_2","walk_2","attack_2","gethit_2"};
	private Animation _animation;
	private bool hasattacked = false;
	// Use this for initialization
	void Start () {
		_animation = this.GetComponent<Animation> ();

	}

	// Update is called once per frame
	void Update () {
		if (bossstate == BossState.noani) {
			if(playerstate.ani_stat==playerStateLinster.enum_ani_state.Attacking1)
			{
				if(Vector3.Distance(player.position,transform.position)<(float)0.5&& Vector3.Angle(player.transform.forward,transform.position-player.transform.position)<60)
				{
					StartCoroutine( WaitForAnimationPlayOver((int)BossState.gethit));
					Debug.Log ("boss xue down");
				}
			}
			int temp =Random.Range(0,100);
			if(temp%4==0)
			{
				StartCoroutine( WaitForAnimationPlayOver((int)BossState.idle));
			}
			else if(temp%4==1)
			{
				StartCoroutine( WaitForAnimationPlayOver((int)BossState.walk));
			}
			else if(temp%4==2)
			{
				StartCoroutine( WaitForAnimationPlayOver((int)BossState.attack));
			}
		}
		if (bossstate == BossState.walk) {
			transform.LookAt(player.position);
			transform.position +=transform.forward *Time.deltaTime;
		}
		if(bossstate==BossState.attack)
		{
			if(!hasattacked && Vector3.Distance(player.position,transform.position)<(float)0.5)
			{
				player.animation.CrossFade("hit");
				playerstate.xueDownRandom();
				hasattacked =true;
			}
		}
	}
	IEnumerator WaitForAnimationPlayOver(int attackstyle)
	{
		//Debug.Log(Time.time);
		bossstate =(BossState) attackstyle;
		yield return new WaitForSeconds(_animation[aniName[attackstyle]].length);
		bossstate = BossState.noani;
		hasattacked = false;
		//playerstate.setAniState((int)playerStateLinster.enum_ani_state.NoAni);
		
		//Debug.Log(Time.time);
		
		//Debug.Log (_animation [animationName].length);
		
	}
}
