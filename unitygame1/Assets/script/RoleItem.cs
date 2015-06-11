using UnityEngine;
using System.Collections;

public class RoleItem : MonoBehaviour 
{
	public UILabel txtName;
	public UISprite bar;
	public UILabel txtBlood;
	public int fullXue=150;
	public int curXue=50;
	private int height =13;
	private int yoffset =-7;
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

		this.bar.SetRect (-fullXue/2, yoffset, curXue, height);
	}

	public void ChangeDepth(int depth)
	{
		this.uiPanel.depth = depth;
	}
	public void setbarwide(int wide)
	{
		this.bar.SetRect (-fullXue, yoffset, wide, height);
	}
	public void subRandomXue()
	{

	}
}
