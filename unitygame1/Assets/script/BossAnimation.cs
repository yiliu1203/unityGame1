using UnityEngine;
using System.Collections;

public class BossAnimation : MonoBehaviour {

	public Transform player;
	public playerStateLinster playerstate;
	public enum  BossState {idle=0,walk,attack,gethit,noani}
	public BossState bossstate=BossState.noani;
	private string[] aniName={"idle_2","walk_2","attack_3","gethit_2"};
	private Animation _animation;
	private bool hasattacked = false;
	private bool haswalkredirect=false;

	public int curXue=200;
	public int fullXue=200;
	public UISprite  xuekuang;
	public UILabel xuelable;

	// Use this for initialization
	void Start () {
		_animation = this.GetComponent<Animation> ();

	}

	// Update is called once per frame
	void Update () {
		xuekuang.SetRect (25, -8, curXue, 15);
		xuelable.text = curXue.ToString();

		if(playerstate.ani_stat==playerStateLinster.enum_ani_state.Attacking1&& bossstate!=BossState.gethit)
		{
			if(Vector3.Distance(player.position,transform.position)<(float)0.5&& Vector3.Angle(player.transform.forward,transform.position-player.transform.position)<60)
			{
				curXue -=Random.Range(20,25);
				StartCoroutine( WaitForAnimationPlayOver((int)BossState.gethit));
				//Debug.Log ("boss xue down");
			}
		}

		if (bossstate == BossState.noani) {
			//if(playerstate.ani_stat==playerStateLinster.enum_ani_state.Attacking1)
			//{
			//	if(Vector3.Distance(player.position,transform.position)<(float)0.5&& Vector3.Angle(player.transform.forward,transform.position-player.transform.position)<60)
			//	{
			//		StartCoroutine( WaitForAnimationPlayOver((int)BossState.gethit));
			//		Debug.Log ("boss xue down");
			//	}
			//}
			int temp =Random.Range(0,100);
			if(temp<=10 && Vector3.Distance(player.position,transform.position)>2)
			{
				StartCoroutine( WaitForAnimationPlayOver((int)BossState.idle));
			}
			else if(temp<=40 && temp>20 && Vector3.Distance(player.position,transform.position)>2)
			{
				StartCoroutine( WaitForAnimationPlayOver((int)BossState.walk));
			}
			else if(Vector3.Distance(player.position,transform.position)<1)
			{
				StartCoroutine( WaitForAnimationPlayOver((int)BossState.attack));
			}
		}
		if (bossstate == BossState.walk) {
			if(!haswalkredirect)
			{
				//transform.LookAt(player.position);
				//haswalkredirect =true;
				float temp =Vector3.Angle(transform.forward,player.position -transform.position);
				if(Vector3.Dot(transform.forward,player.position-transform.position)>0)
				{
					transform.Rotate(0,-temp,0);
				}
				else {transform.Rotate(0,temp,0);}
				haswalkredirect =true;
			}
			Vector3 tempv =transform.forward;
			tempv.y=0;
			transform.position +=tempv *Time.deltaTime;
		}
		if(bossstate==BossState.attack)
		{
			if(!hasattacked && Vector3.Distance(player.position,transform.position)<(float)0.5)
			{
				transform.LookAt(player.position);
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
		_animation.Stop ();
		_animation.CrossFade (aniName [attackstyle]);
		yield return new WaitForSeconds(_animation[aniName[attackstyle]].length);
		bossstate = BossState.noani;
		hasattacked = false;
		haswalkredirect = false;
		//playerstate.setAniState((int)playerStateLinster.enum_ani_state.NoAni);
		
		//Debug.Log(Time.time);
		
		//Debug.Log (_animation [animationName].length);
		
	}
}
