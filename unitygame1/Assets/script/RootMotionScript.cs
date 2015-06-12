using UnityEngine;
using System.Collections;

public class RootMotionScript : MonoBehaviour {

	// Use this for initialization
	public Transform hero;
	private Animator _animator;
	public RolePropertyItem rolePropertyItem;
	void Start () {
		 _animator = GetComponent<Animator>(); 
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	void OnAnimatorMove()
	{
		if (_animator)
		{
			AnimatorStateInfo aniInfo =_animator.GetCurrentAnimatorStateInfo(0);

			if(aniInfo.IsName("Base Layer.gethit"))
			{
				if(rolePropertyItem.getCurXue()>0 && !rolePropertyItem.shouldStandup())
				{
				_animator.SetBool("walk2idle",true);
				_animator.SetBool("idle2gethit",false);
				_animator.SetBool("walk2gethit",false);
				_animator.SetBool("idle2walk",true);
				_animator.SetBool("walk2idle",true);
			
				}
				if(rolePropertyItem.shouldStandup())
				{
					_animator.SetBool("gethit2depth",true);
					_animator.SetBool("idle2gethit",false);
					_animator.SetBool("walk2gethit",false);
				}
			}

			if(aniInfo.IsName("Base Layer.depth1"))
			{
				if(rolePropertyItem.getCurXue()>0)
				{
					_animator.SetBool("depth2standup",true);
				}
				else _animator.SetBool("depth2standup",false);
			}

			if(aniInfo.IsName("Base Layer.walk")){
				transform.LookAt(hero.transform);
				Vector3 newPosition = transform.position;
				transform.position +=transform.forward *Time.deltaTime *_animator.GetFloat("walkspeed");
				//transform.forward);
				//newPosition.z +=animator.GetFloat("walkspeed") * Time.deltaTime; 
				//transform.position = newPosition;
//				Debug.Log(animator.GetFloat("walkspeed"));
			}

		}
	}
}
