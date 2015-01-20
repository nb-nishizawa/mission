using UnityEngine;
using System.Collections;

public class ParticleScript : MonoBehaviour {

	private float timer;

	// Use this for initialization
	void Start () {
		timer = 0;
	}

	public void Create(GameObject bombObj) {
		// パーティクル生成したときにBombオブジェクト消す感じで
		SetBomb setBomb = GameObject.Find ("unitychan").GetComponent<SetBomb> ();
		setBomb.bombList.Remove (bombObj);
		Destroy (bombObj);
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		// 爆発終了後削除
		// タイマーを仕込むことで生まれたばかりのパーティクルオブジェクトを保護する
		if (gameObject.particleSystem != null &&
		    gameObject.particleSystem.particleCount == 0 &&
		    timer > gameObject.particleSystem.startLifetime) {
			Destroy (gameObject);
		}
	}

	void OnParticleCollision(GameObject obj) {
		if (obj.name == "BombPrefab(Clone)") {
			obj.GetComponent<UpdateBomb> ().explosionBomb ();
		} else if (obj.name == "unitychan") {
			obj.GetComponent<UnityChan.UnityChanControlScriptWithRgidBody> ().damage ();
		} else if (obj.name == "block") {
			GameObject trn = GameObject.Find("Terrain");
			trn.GetComponent<CreateField> ().deleteBlock (obj);
		} else {
//			Debug.Log(obj.name);
		}
	}
}
