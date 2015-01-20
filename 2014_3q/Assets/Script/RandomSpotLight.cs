using UnityEngine;
using System.Collections.Generic;

public class RandomSpotLight : MonoBehaviour {

	private GameObject spotLight;
	private List<GameObject> lightList;
	private GameObject lastLight;

	// Use this for initialization
	void Start () {
		lightList = new List<GameObject>();
		spotLight = (GameObject)Resources.Load ("Prefabs/SpotLightPrefab");
		InvokeRepeating("Create", 1.0f, 0.01f);
	}
	
	// Update is called once per frame
	void Update () {
		if (lastLight) {
			if (lastLight.light.intensity <= 0) {
				// ここでシーン移動的な
				Destroy(lastLight);
				Application.LoadLevelAdditive ("GameScene");
			}
		}
	}
	void Create () {
//		if (lightList.Count < 200) {
//			int x = Random.Range(-12,13);
//			int y = Random.Range(-5,6);
//			foreach (GameObject obj in lightList) {
//				if (obj.transform.position.x == x && obj.transform.position.y == y) continue;
//			}
//			lightList.Add((GameObject)Instantiate(spotLight, new Vector3(x,y,0), Quaternion.identity));
//		} else {
//			foreach(GameObject obj in lightList) {
//				Destroy(obj);
//			}
			CancelInvoke();
			lastLight = (GameObject)Instantiate(spotLight, new Vector3(0,0,0), Quaternion.identity);
			lastLight.light.spotAngle = 150;
//		}
	}
}
