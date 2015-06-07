﻿using UnityEngine;
using System.Collections;

public class otherInput : MonoBehaviour {

	// Use this for initialization
	private Animation _animation;
	private playerStateLinster playerstate;

	public WeaponTrail myTrail;
	private float t = 0.033f;
	private float tempT = 0;
	private float animationIncrement = 0.003f;

	void Start () {
		playerstate = GameObject.FindWithTag ("scriptObj").GetComponent<playerStateLinster> ();
		_animation = GameObject.FindWithTag ("Player").GetComponent<Animation> ();
		_animation.wrapMode = WrapMode.Once;
		AnimationState attack1_state =_animation["attack1"];
		attack1_state.layer = 1;
		attack1_state.weight = 1;
		//attack1_state.enabled = true;
	}

	void LateUpdate()
	{
		if (playerstate.ani_stat == playerStateLinster.enum_ani_state.Trotting||playerstate.ani_stat == playerStateLinster.enum_ani_state.Walking ) {

			myTrail.UpdateTrail(0,0);

		//	myTrail.ClearTrail();
		//	if(myTrail.time<0) myTrail.ClearTrail();
			return ;
		}

		t = Mathf.Clamp(Time.deltaTime, 0, 0.066f);
		
		if (t > 0)
		{
			while (tempT < t)
			{
				tempT += animationIncrement;
				
				if (myTrail.time > 0)
				{
					myTrail.Itterate(Time.time - t + tempT);
				}
				else
				{
					myTrail.ClearTrail();
				}
			}
			
			tempT -= t;
			
			if (myTrail.time > 0)
			{
				myTrail.UpdateTrail(Time.time, t);
			}
		}
	}


	void OnGUI()
	{
//		if (GUI.Button (new Rect (50, 50, 50, 50), "attack")) {
//			toattack = true;
//		} else {
//			toattack =false;
//		}
	}
	// Update is called once per frame
	void Update () {
		if ( Input.GetMouseButton(0)&& playerstate.ani_stat!=playerStateLinster.enum_ani_state.Attacking1) {
			Debug.Log("mouse left down");
			_animation.Stop();
			_animation.CrossFade("attack1");

			//Debug.Log("test");
			//Debug.Log(Time.time);
			StartCoroutine(WaitForAnimationPlayOver("attack1"));		// 注意这里startcoroutine的区别
			//WaitForAnimationPlayOver("attack1");
		//	Debug.Log(Time.time);
			//

		}
		if (Input.GetAxis ("Vertical") < -0.2) {
		//	animation.Stop();
		}
	}
	IEnumerator WaitForAnimationPlayOver(string animationName)
	{
		//Debug.Log(Time.time);
		playerstate.setAniState((int)playerStateLinster.enum_ani_state.Attacking1);
		yield return new WaitForSeconds(_animation[animationName].length);
		playerstate.setAniState((int)playerStateLinster.enum_ani_state.NoAni);
		//Debug.Log(Time.time);

		//Debug.Log (_animation [animationName].length);
	
	}
}
