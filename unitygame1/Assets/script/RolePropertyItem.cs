using UnityEngine;
using System.Collections;

public class RolePropertyItem : MonoBehaviour 
{
	private float formatDistance = 4f;

	public GameObject itemRoot;

	protected RoleItem roleItem;
	public Camera uicama;


	void Awake()
	{

		GameObject gameObject = Resources.Load<GameObject> ("RoleItem");

		if (gameObject != null) 
		{
			GameObject roleNameObject = (GameObject)Instantiate(gameObject);
			roleNameObject.transform.localScale = new Vector3(1f, 1f, 1f);
			roleNameObject.transform.position = this.transform.InverseTransformPoint(this.transform.position);
			roleNameObject.transform.parent = this.itemRoot.transform;
			this.roleItem = roleNameObject.GetComponent<RoleItem>();
		}
	}
	
	void Update()
	{
		// 如果没有设置血条位置
		if (this.roleItem == null) return;
		
		Vector3 directionVector = this.transform.position - Camera.main.transform.position;
		// 计算血条与摄像机的夹角
		float angleValue = Vector3.Angle (directionVector, Camera.main.transform.forward);
		
		// 如果在摄像机范围内，显示，否则隐藏
		if (angleValue < Camera.main.fieldOfView) 
		{
			NGUITools.SetActive(this.roleItem.gameObject, true);
			// 角色离摄像机的距离
			float distance = Vector3.Distance(this.transform.position, Camera.main.transform.position);
			//根据距离设置缩放比例
			this.roleItem.transform.localScale = Vector3.one * (this.formatDistance / distance);
			this.roleItem.transform.position = this.WorldToScreenPosition(this.transform.position);
			// 更新血条深度
			this.roleItem.ChangeDepth(-(int)distance);
		}
		else 
		{
			NGUITools.SetActive(this.roleItem.gameObject, false);
		}
	}
	
	private Vector3 WorldToScreenPosition(Vector3 position)
	{

			return uicama.ScreenToWorldPoint(Camera.main.WorldToScreenPoint(position));

	}

	public void subXue( )
	{
		roleItem.subDownRandomXue ();
	}
	public int getCurXue()
	{
		return roleItem.curXue;
	}
	public bool shouldStandup()
	{
		return roleItem.curXue % 3 == 0;
		//return roleItem.curXue < (roleItem.fullXue / 2 + 5) && (roleItem.curXue > roleItem.fullXue - 5);
		//return true;
	}
}
