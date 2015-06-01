using UnityEngine;
using System.Collections;

public class camaTrack : MonoBehaviour {
	public Transform [] transobj;
	private Animator [] animator;
	public float speed=10;
	// Use this for initialization
	void Start () {
		animator = new Animator[transobj.Length];
		for (int i=0; i<transobj.Length; i++) {
			animator[i]=transobj[i].GetComponent<Animator>();
		}
	}
	
	// Update is called once per frame
	void Update () {
		float tranX = Input.GetAxis ("Vertical") * speed;
		float tranZ = Input.GetAxis ("Horizontal") * speed;
		tranX *= Time.deltaTime;
		tranZ *= Time.deltaTime;
		for (int i=0; i<transobj.Length; i++) {
			transobj[i].transform.Translate(new Vector3(tranX,0,tranZ));
		}
	
	}
}
