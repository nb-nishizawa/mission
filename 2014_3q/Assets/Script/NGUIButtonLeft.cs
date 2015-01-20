using UnityEngine;
using System.Collections;

public class NGUIButtonLeft : MonoBehaviour {
	
	public bool status;
	
	/**
	 * ボタン取得状況的なもの 
	 */
	void OnPress (bool isDown) {
		this.status = isDown;
	}
}
