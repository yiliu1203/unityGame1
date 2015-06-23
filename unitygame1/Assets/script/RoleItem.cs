using UnityEngine;
using System.Collections;

public class RoleItem : MonoBehaviour 
{
	public UILabel txtName;
	public UISprite bar;
	public UILabel txtBlood;
	public int fullXue=150;
	public int curXue=150;
	private int height =13;
	private int yoffset =-7;
	 playerStateLinster state;
	/// <summary>
	/// 血条宽
	/// </summary>
	public float itemWidth;

	/// <summary>
	/// 血条高
	/// </summary>
	public float itemHeight;

	private UIPanel uiPanel;

	void Awake()
	{
		this.uiPanel = this.GetComponentInParent<UIPanel> ();

	}


	void Start()
	{
		this.bar.SetRect (-75, -7, curXue, height);
		state = GameObject.FindWithTag ("scriptObj").GetComponent<playerStateLinster> ();
	}

	public void ChangeDepth(int depth)
	{
		this.uiPanel.depth = depth;
	}
	public void setbarwide(int wide)
	{
		this.bar.SetRect (-75, yoffset, wide, height);
		this.txtBlood.text = wide.ToString ();
	}
	public void subDownRandomXue()
	{
		int temp = 0;
		temp =(int)state.tool_stat * 5;
		int num = Random.Range (20, 30) +temp;
		curXue -= num;
		if (curXue < 0) {
			curXue =0;
			//Time.timeScale =0;
			//GameObject.FindWithTag("scriptObj").GetComponent<otherInput>().togameover(0);
		}
		setbarwide (curXue);
		//Debug.Log (curXue);	
	}

}
