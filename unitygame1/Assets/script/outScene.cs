using UnityEngine;
using System.Collections;

public class outScene : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.name == "dwarf_07") {
			Time.timeScale=0;
			GameObject.FindWithTag("scriptObj").GetComponent<otherInput>().togameover(1);


		}
	}
}
