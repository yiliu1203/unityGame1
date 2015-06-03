using UnityEngine;
using System.Collections;

public class camaTrack : MonoBehaviour {
	public Transform [] transobj;
	private Animator [] animator;
	public float speed=10;
	private static Vector3 preposition =new Vector3(0,0,0);
	// Use this for initialization
	void Start () {
		animator = new Animator[transobj.Length];
		for (int i=0; i<transobj.Length; i++) {
			animator[i]=transobj[i].GetComponent<Animator>();
		}
		preposition = transobj [0].transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		float tranZ = Input.GetAxis ("Vertical");
		float tranX = Input.GetAxis ("Horizontal");
		animator [0].SetBool ("idle2walk", false);
		animator [0].SetBool ("walk2idle", false);
//		tranX *= Time.deltaTime;
//		tranZ *= Time.deltaTime;
//		for (int i=0; i<transobj.Length; i++) {
//			transobj[i].transform.Translate(new Vector3(tranX,0,tranZ));
//		}	
		Vector3 localrotate = transobj [0].eulerAngles;

		if (tranX > 0) {
			transobj [0].eulerAngles = new Vector3 (0, 90, 0);
			if(tranX>0.5){
				animator[0].SetBool("idle2walk",true);
			}
		} else if (tranX < 0) {
			transobj[0].eulerAngles =new Vector3(0,270,0);
			if(tranX<-0.5)
			{
				animator[0].SetBool("idle2walk",true);
			}
		}
		if (tranZ > 0) {
			transobj [0].eulerAngles = new Vector3 (0, 0, 0);
			if (tranZ > 0.5) {
				animator [0].SetBool ("idle2walk", true);
			}
		} else if (tranZ < 0) {
			transobj[0].eulerAngles =new Vector3(0,180,0);
			if(tranZ<-0.5)
			{
				animator[0].SetBool("idle2walk",true);
			}
		}
		Vector3 curposition = transobj[0].transform.position;
		if (curposition != preposition) {
			Vector3 tranes =curposition -preposition;
			preposition =curposition;
		//	Debug.Log (tranes);
			transform.LookAt(transobj[0].transform.position);
			transform.Translate(tranes);

		}

	}
}
