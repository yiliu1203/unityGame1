using UnityEngine;
using System.Collections;

public class RootMotionScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnAnimatorMove()
	{
		Animator animator = GetComponent<Animator>(); 
		
		if (animator)
		{
			Vector3 newPosition = transform.position;
			newPosition.z +=animator.GetFloat("walkspeed") * Time.deltaTime; 
			transform.position = newPosition;
			Debug.Log(animator.GetFloat("walkspeed"));

		}
	}
}
