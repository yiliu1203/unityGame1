using UnityEngine;
using System.Collections;

public class nguiClick : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnClick()
	{
		if (Time.timeScale != 0)
			Time.timeScale = 0;
		else
			Time.timeScale = 1;
	}
}
