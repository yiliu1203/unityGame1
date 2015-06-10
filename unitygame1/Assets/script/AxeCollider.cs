using UnityEngine;
using System.Collections;

public class AxeCollider : MonoBehaviour {

	// Use this for initialization
	public enum tool_state{ONGround=0,Unvisible,PreFlying,Flying};
	public tool_state currentState=tool_state.ONGround;
	private Transform scriptobj;
	private GameObject gameobj3;
	private playerStateLinster playerstate;
	private Vector3 startPos;
	private Vector3 endPos;
	private Transform player;
	public  enum FlyingTool{None=0,hammer=1, axe};
	public  FlyingTool activeTool=FlyingTool.None;
	
	void Start () {
		scriptobj = GameObject.FindWithTag ("scriptObj").transform;
		playerstate = scriptobj.GetComponent<playerStateLinster> ();
		playerstate.setToolState (0);
		player =GameObject.FindWithTag("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {

		//Debug.Log (currentState);
		if (currentState == tool_state.PreFlying) {

			if(activeTool ==FlyingTool.hammer)
			{
				GameObject.FindWithTag ("hammer_in_hand").SetActive(true);
			}
			else if(activeTool ==FlyingTool.axe)
			{
				GameObject.FindWithTag ("axe_in_hand").SetActive(true);
			}
			RaycastHit hitt = scriptobj.GetComponent<otherInput> ().hitt;
			startPos = player.position;
			endPos = hitt.point;
			startPos.y += (float)0.3;
			endPos .y += (float)0.3;
			this.transform.position = startPos;
			this.transform.LookAt (endPos);
			currentState = tool_state.Flying;
			display();

		}
		else if (currentState == tool_state.Flying) {
			Debug.Log("should flying");
			transform.position = Vector3.Slerp(startPos,endPos,Time.deltaTime);  
			//transform.Translate(transform.forward *(float)0.01);
			//transform.position =Vector3.MoveTowards(startPos, endPos, (float)10 * Time.deltaTime);
			if(Vector3.Distance(this.transform.position,endPos)<0.1)
			{
			
				transform.position =endPos;
				transform.position +=transform.forward *(float)0.5;
				currentState =tool_state.ONGround;

				//transform.GetComponent<ParticleSystem>().enableEmission =true;

			}


		}
	}

	void OnCollisionEnter( Collision collision)
	{
		//Debug.Log("collision");
		Debug.Log (collision.collider.name);
		var b = this.transform.GetComponent<Rigidbody> ();
		Destroy (b);
		this.transform.GetComponent<Collider> ().isTrigger = true;
		this.transform.position +=new  Vector3 (0, (float)0.2, 0);
	}

	void OnTriggerEnter(Collider collider)
	{
		GameObject.FindWithTag ("hammer_in_hand").GetComponent<MeshRenderer> ().enabled = false;
		GameObject.FindWithTag ("axe_in_hand").GetComponent<MeshRenderer> ().enabled = false;
		//Debug.Log (this.tag);
		if (currentState == tool_state.ONGround && collider.name == "dwarf_07") {
			Debug.Log("shoun on gound");
			if (this.tag == "hammer_in_gound") {
				var gameobj1 = GameObject.FindWithTag ("Partical_sys1");

				var partical = gameobj1.transform.GetComponent<ParticleSystem> ();
				partical.enableEmission = false;
				var gameObj2 = GameObject.FindWithTag ("hammer_in_hand");
				gameObj2.GetComponent<MeshRenderer> ().enabled = true;
			//	GameObject.FindWithTag ("hammer_in_gound").SetActive (false);
				disappear();
				playerstate.setToolState ((int)playerStateLinster.enum_tool_state.Hammer);
				GameObject.FindWithTag ("Tail").GetComponent<MeshRenderer> ().enabled = false;
			} else if (this.tag == "axe_in_gound") {
				var gameobj1 = GameObject.FindWithTag ("Partical_sys2");		
				var partical = gameobj1.transform.GetComponent<ParticleSystem> ();
				partical.enableEmission = false;
				var gameObj2 = GameObject.FindWithTag ("axe_in_hand");
				gameObj2.GetComponent<MeshRenderer> ().enabled = true;
				//GameObject.FindWithTag ("axe_in_gound").SetActive (false);
				disappear();
				playerstate.setToolState ((int)playerStateLinster.enum_tool_state.Axe);
				GameObject.FindWithTag ("Tail").GetComponent<MeshRenderer> ().enabled = true;

			}
			currentState =tool_state.Unvisible;
		}
	}

	void disappear()
	{
		for (int i=0; i<transform.childCount; i++) {
			transform.GetChild(i).gameObject.SetActive(false);
		}
	}
	void display()
	{

		for (int i=0; i<transform.childCount; i++) {
			transform.GetChild(i).gameObject.SetActive(true);
		}
	}
	public void  setFlyintTool(int state)
	{
		FlyingTool temp = (FlyingTool)state;
		activeTool = temp;
	}
	public void settoolState(int state,int tool)
	{
		tool_state temp = (tool_state)state;
		currentState = temp;
	
		setFlyintTool (tool);
	}
}
