using UnityEngine;

public class UpdateBomb : MonoBehaviour {

	public float scale;
	public float range;
	public int explosionTime;
	public float timer;
	private GameObject explosion;

	// Use this for initialization
	void Start () {
		scale = 1;
		range = 0.5f;
		explosionTime = 3;
		timer = 0;
		explosion = (GameObject)Resources.Load ("Prefabs/ExplosionPrefab");
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;
		// 設置後
		if (timer < explosionTime) {		
			if (this.transform.localScale.x > 1.1f || this.transform.localScale.x < 1.0f) {
				range *= -1;
			}
			scale = scale + range * Time.deltaTime;
			this.transform.localScale = new Vector3 (scale, scale, scale);
		// 爆発させる
		} else {
			// ここにパーティクル処理追加すればいいのかなあ
			explosionBomb();
		}
	}

	// 爆発だー！
	public void explosionBomb() {
		GameObject explosionObj = (GameObject)Instantiate (explosion, gameObject.transform.position, Quaternion.identity);
		explosionObj.GetComponent<ParticleScript>().Create(gameObject);
	}
}
