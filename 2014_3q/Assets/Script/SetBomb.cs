using UnityEngine;
using System.Collections.Generic;

public class SetBomb : MonoBehaviour {
	
	private GameObject bomb;
	private GameObject unityChan;
	public List<GameObject> bombList;

	// Use this for initialization
	void Start () {
		bombList = new List<GameObject>();
		bomb = (GameObject)Resources.Load ("Prefabs/BombPrefab");
		unityChan = GameObject.Find ("unitychan");
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.Mouse0)) {
			bombList.Add((GameObject)Instantiate(bomb, unityChan.transform.position, Quaternion.identity));
		}
		// debug
		if (Input.GetKeyDown (KeyCode.Mouse1)) {
			if (bombList.Count > 0) {
				Destroy (bombList[0]);
				bombList.RemoveAt(0);
			}
		}
	}
}
