using UnityEngine;
using System.Collections;

public class otherInput : MonoBehaviour {

	// Use this for initialization

	public Camera  came;
	public RaycastHit hitt = new RaycastHit(); 
	public Transform hammer_in_gound;
	public Transform axe_in_gound;
	public Transform player;
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
		if ( Input.GetMouseButtonDown(0)&& playerstate.ani_stat!=playerStateLinster.enum_ani_state.Attacking1) {

			_animation.Stop();
			_animation.CrossFade("attack1");

			//Debug.Log("test");
			//Debug.Log(Time.time);
			StartCoroutine(WaitForAnimationPlayOver("attack1"));		// 注意这里startcoroutine的区别
			//WaitForAnimationPlayOver("attack1");
		//	Debug.Log(Time.time);
			//

		}
		if (Input.GetMouseButtonDown(1) &&playerstate.ani_stat!=playerStateLinster.enum_ani_state.Attacking1) {
		//	animation.Stop();

			if(playerstate.tool_stat==playerStateLinster.enum_tool_state.Axe)
			{
				if(	axe_in_gound.GetComponent<AxeCollider>().currentState!=AxeCollider.tool_state.Unvisible)
				{
					return ;
				}
			}
			if(playerstate.tool_stat==playerStateLinster.enum_tool_state.Hammer)
			{
				if(	hammer_in_gound.GetComponent<AxeCollider>().currentState!=AxeCollider.tool_state.Unvisible)
				{
					return ;
				}
			}

			Ray ray = came.ScreenPointToRay(Input.mousePosition); 
			Physics.Raycast(ray, out hitt, 100); 
			//Debug.DrawLine(came.transform.position, ray.direction,Color.red); 

			if (null != hitt.transform ) {

				Vector3 v1 =hitt.point -player.transform.position;
				Vector3 v2 =player.transform.forward;
			
				if(Vector3.Angle(v1,v2)>20)
				{
					return ;
				}

				//print(hitt.point);
			//	Debug.Log(hitt.collider.gameObject.name);

				GameObject.FindWithTag ("hammer_in_hand").GetComponent<MeshRenderer> ().enabled = false;
				GameObject.FindWithTag ("axe_in_hand").GetComponent<MeshRenderer> ().enabled = false;
				GameObject.FindWithTag ("Tail").GetComponent<MeshRenderer> ().enabled = false;

				if(playerstate.tool_stat ==playerStateLinster.enum_tool_state.Axe)
				{
					axe_in_gound.GetComponent<AxeCollider>().settoolState(2,2);
					_animation.CrossFade("attack1");
					StartCoroutine(WaitForAnimationPlayOver("attack1"));

				}
				else if(playerstate.tool_stat ==playerStateLinster.enum_tool_state.Hammer)
				{				
					hammer_in_gound.GetComponent<AxeCollider>().settoolState(2,1);
					_animation.CrossFade("attack1");
					StartCoroutine(WaitForAnimationPlayOver("attack1"));
				}
			}
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
