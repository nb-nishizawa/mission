using UnityEngine;
using System.Collections;

public class JoyStick : MonoBehaviour {
	
	public GameObject AttachJoyStickSprite, AttachJoyStickBackSprite;
	public Camera AttachGUICamera;

	private NGUIButtonBomb btnBomb;
	
	private Vector2 _position;
	public Vector2 Position{
		get{return _position;}
	}

	private float _maxRadius;
	private const float MAX_RADIUS_RATE = 0.55f;
	
	//=================================================================================
	//初期化
	//=================================================================================
	
	private void Awake (){
		_position = Vector2.zero;
		_maxRadius = 1;
		btnBomb = GameObject.Find ("ButtonBomb").GetComponent<NGUIButtonBomb> ();
	}
	
	//=================================================================================
	//更新
	//=================================================================================
	
	private void Update () {
		if (!btnBomb.status) {
			DisplayConfirmation ();
			Move ();
		}
	}
	
	//ジョイスティックの表示確認
	private void DisplayConfirmation(){
		
		if (Input.GetMouseButtonDown(0)){
			AttachJoyStickBackSprite.SetActive (true);
			
			AttachJoyStickBackSprite.transform.position = AttachGUICamera.ScreenToWorldPoint(Input.mousePosition);
			AttachJoyStickSprite.transform.position = Vector3.zero;
		}
		else if (Input.GetMouseButtonUp(0)){
			AttachJoyStickBackSprite.SetActive (false);
			_position = Vector2.zero;
		}

		AttachJoyStickSprite.transform.parent = AttachJoyStickBackSprite.transform;
		AttachJoyStickSprite.transform.localScale = new Vector3(1, 1, 0);
	}
	
	//ジョイスティックをタッチされている場所に伴って移動
	private void Move(){
		
		//表示されていなければ移動しない
		if(!AttachJoyStickBackSprite.activeSelf){
			return;
		}
		
		Vector3 touchPosition = AttachGUICamera.ScreenToWorldPoint(Input.mousePosition);
		AttachJoyStickSprite.transform.position = touchPosition;
		
		//半径が制限を超えてる場合は制限内に抑える
		float radius = Vector3.Distance (Vector3.zero, AttachJoyStickSprite.transform.localPosition);
		if(radius > _maxRadius){
			
			//角度
			float radian = CalcRadian(
				Vector3.zero,
				AttachJoyStickSprite.transform.localPosition
				);
			
			Vector3 setVec = Vector3.zero;
			setVec.x = _maxRadius * Mathf.Cos (radian);
			setVec.y = _maxRadius * Mathf.Sin (radian);
			
			AttachJoyStickSprite.transform.localPosition = setVec;
		}
		
		//-1〜1に正規化
		_position = new Vector2 (
			AttachJoyStickSprite.transform.localPosition.x / _maxRadius,
			AttachJoyStickSprite.transform.localPosition.y / _maxRadius
			);
		
	}
	
	//2点間の角度を求める
	private float CalcRadian(Vector3 from, Vector3 to) {
		float dx = to.x - from.x;
		float dy = to.y - from.y;
		float radian = Mathf.Atan2(dy, dx);
		return radian;
	}
	
} 