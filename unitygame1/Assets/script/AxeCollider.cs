using UnityEngine;
using System.Collections;

public class AxeCollider : MonoBehaviour {

	// Use this for initialization
	private GameObject gameobj3;
	private playerStateLinster playerstate;
	void Start () {
		playerstate = GameObject.FindWithTag ("scriptObj").GetComponent<playerStateLinster> ();
		playerstate.setToolState (0);
	}
	
	// Update is called once per frame
	void Update () {

	}
	void OnTriggerEnter(Collider collider)
	{
		GameObject.FindWithTag ("hammer_in_hand").GetComponent<MeshRenderer> ().enabled = false;
		GameObject.FindWithTag ("axe_in_hand").GetComponent<MeshRenderer> ().enabled = false;
		//Debug.Log (this.tag);
		if (this.tag == "hammer_in_gound") {
			var gameobj1 = GameObject.FindWithTag ("Partical_sys1");

			var partical = gameobj1.transform.GetComponent<ParticleSystem> ();
			partical.enableEmission = false;
			var gameObj2 = GameObject.FindWithTag ("hammer_in_hand");
			gameObj2.GetComponent<MeshRenderer> ().enabled = true;
			GameObject.FindWithTag ("hammer_in_gound").SetActive (false);
			playerstate.setToolState((int)playerStateLinster.enum_tool_state.Hammer);
			GameObject.FindWithTag("Tail").GetComponent<MeshRenderer>().enabled=false;
		}
		else if (this.tag == "axe_in_gound") {
			var gameobj1 = GameObject.FindWithTag ("Partical_sys2");		
			var partical = gameobj1.transform.GetComponent<ParticleSystem> ();
			partical.enableEmission = false;
			var gameObj2 = GameObject.FindWithTag ("axe_in_hand");
			gameObj2.GetComponent<MeshRenderer> ().enabled = true;
			GameObject.FindWithTag ("axe_in_gound").SetActive (false);
			playerstate.setToolState((int)playerStateLinster.enum_tool_state.Axe);
			GameObject.FindWithTag("Tail").GetComponent<MeshRenderer>().enabled=true;
			
		}







	}
}
