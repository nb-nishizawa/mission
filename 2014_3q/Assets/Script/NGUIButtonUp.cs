using UnityEngine;
using System.Collections;

public class NGUIButtonUp : MonoBehaviour {
	
	public bool status;
	
	/**
	 * ボタン取得状況的なもの 
	 */
	void OnPress (bool isDown) {
		this.status = isDown;
	}
}
