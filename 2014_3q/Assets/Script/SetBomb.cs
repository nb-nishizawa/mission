using UnityEngine;
using System.Collections.Generic;

public class SetBomb : MonoBehaviour {

	public float timer;
	private GameObject bomb;
	private GameObject unityChan;
	private NGUIButtonBomb btnBomb;
	private bool prevBtnStatus;
	public List<GameObject> bombList;

	// Use this for initialization
	void Start () {
		bombList = new List<GameObject>();
		bomb = (GameObject)Resources.Load ("Prefabs/BombPrefab");
		unityChan = GameObject.Find ("unitychan");
		
		btnBomb = GameObject.Find ("ButtonBomb").GetComponent<NGUIButtonBomb> ();
	}

	// Update is called once per frame
	void Update () {
		if (btnBomb.status && !prevBtnStatus &&
		    !(unityChan.GetComponent<UnityChan.UnityChanControlScriptWithRgidBody> ().checkDamageState ())) {
			float x,y,z;
			x = unityChan.transform.position.x;
			y = unityChan.transform.position.y + bomb.transform.localScale.y / 2;
			z = unityChan.transform.position.z;
			bombList.Add((GameObject)Instantiate(bomb, new Vector3(x, y, z), Quaternion.identity));
		}
		prevBtnStatus = btnBomb.status;
	}
}
