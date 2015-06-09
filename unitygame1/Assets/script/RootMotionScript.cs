using UnityEngine;
using System.Collections;

public class RootMotionScript : MonoBehaviour {

	// Use this for initialization
	public Transform hero;
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
			AnimatorStateInfo aniInfo =animator.GetCurrentAnimatorStateInfo(0);
			if(aniInfo.IsName("Base Layer.walk")){
				transform.LookAt(hero.transform);
				Vector3 newPosition = transform.position;
				transform.position +=transform.forward *Time.deltaTime *animator.GetFloat("walkspeed");
				//transform.forward);
				//newPosition.z +=animator.GetFloat("walkspeed") * Time.deltaTime; 
				//transform.position = newPosition;
//				Debug.Log(animator.GetFloat("walkspeed"));
			}

		}
	}
}
