using UnityEngine;
using System.Collections;

public class otherInput : MonoBehaviour {

	// Use this for initialization

	void Start () {
		animation.wrapMode = WrapMode.Once;
	}
	
	// Update is called once per frame
	void Update () {
	if (Input.GetAxis ("Vertical") > 0.2) {
			animation.CrossFade("walk");
		}
		if (Input.GetAxis ("Vertical") < -0.2) {
			animation.Stop();
		}
	}
}
