using UnityEngine;
using System.Collections;

public class otherInput : MonoBehaviour {

	// Use this for initialization
	private Animation _animation;
	private playerStateLinster playerstate;
	void Start () {
		playerstate = GameObject.FindWithTag ("scriptObj").GetComponent<playerStateLinster> ();
		_animation = GameObject.FindWithTag ("Player").GetComponent<Animation> ();
		_animation.wrapMode = WrapMode.Once;
		AnimationState attack1_state =_animation["attack1"];
		attack1_state.layer = 1;
		attack1_state.weight = 1;
		//attack1_state.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButtonDown(0)) {
			//Debug.Log("mouse left down");
			_animation.Stop();
			_animation.CrossFade("attack1");

			Debug.Log("test");
			Debug.Log(Time.time);
			StartCoroutine(WaitForAnimationPlayOver("attack1"));		// 注意这里startcoroutine的区别
			//WaitForAnimationPlayOver("attack1");
			Debug.Log(Time.time);
			//

		}
		if (Input.GetAxis ("Vertical") < -0.2) {
		//	animation.Stop();
		}
	}
	IEnumerator WaitForAnimationPlayOver(string animationName)
	{
		Debug.Log(Time.time);
		playerstate.setAniState((int)playerStateLinster.enum_ani_state.Attacking1);
		yield return new WaitForSeconds(_animation[animationName].length);
		playerstate.setAniState((int)playerStateLinster.enum_ani_state.NoAni);
		Debug.Log(Time.time);

		//Debug.Log (_animation [animationName].length);
	
	}
}
