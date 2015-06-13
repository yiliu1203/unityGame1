using UnityEngine;
using System.Collections;

public class playerStateLinster : MonoBehaviour {

	// Use this for initialization
	public  enum enum_ani_state{Idle=0,Walking,Trotting,Running,Jumping,Attacking1,Attacking2, NoAni,Depth}
	public   enum enum_tool_state{NoTool=0,Hammer,Axe}
	public enum_ani_state ani_stat;
	public enum_tool_state tool_stat;

	public int curXue=200;
	public int fullXue=200;
	public UISprite  xuekuang;
	public UILabel xuelable;
	public void setAniState(int s)
	{
		enum_ani_state temp = (enum_ani_state)s;
		//if (ani_stat == enum_ani_state.Attacking1 && ani_stat!=enum_ani_state.NoAni)
		//	return;
		ani_stat = temp;
//		Debug.Log (ani_stat);
	}
//	public void setAniState(enum_ani_state s)
//	{
//		ani_stat = s;
//		Debug.Log("state");
//		Debug.Log (ani_stat);
//	}		
	public void setToolState(int s)
	{
		tool_stat =(enum_tool_state)s;
		//Debug.Log (tool_stat);
	}

	public void  setCurXueuang()
	{
		xuekuang.SetRect (25, -8, curXue, 15);
	}

	public void xueDown(int num)
	{
		curXue -= num;
		if (curXue <= 0) {
			curXue =0;
			setCurXueuang();
		}
	}
	public void  xueDownRandom()
	{
		int temp = Random.Range (15, 20);
		xueDown (temp);
	}

	void Start () {
		xuekuang.SetRect (25, -8, curXue, 15);
	}
	
	// Update is called once per frame
	void Update () {
		xuekuang.SetRect (25, -8, curXue, 15);
		xuelable.text = curXue.ToString();
	}
}
