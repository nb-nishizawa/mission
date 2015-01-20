using UnityEngine;
using System.Collections;

public class NGUIButtonBomb : MonoBehaviour {

	public bool status;

	void OnEnable()
	{
		UICamera.fallThrough = gameObject;
	}
	
	void OnDisable()
	{
		UICamera.fallThrough = null;
	}

	/**
	 * ボタン取得状況的なもの 
	 */
	void OnPress (bool isDown) {
		this.status = isDown;
	}
}
