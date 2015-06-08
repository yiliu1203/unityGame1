using UnityEngine;
using System.Collections;

public class RoleItem : MonoBehaviour 
{
	public UILabel txtName;
	public UISprite bar;
	public UILabel txtBlood;

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

	/// <summary>
	/// 更新血条深度
	/// </summary>

	public void ChangeDepth(int depth)
	{
		this.uiPanel.depth = depth;
	}
	public void setbarwide(int wide)
	{
		this.bar.width = wide;
	}
}
