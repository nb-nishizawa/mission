using UnityEngine;
using System.Collections;

public class LightBlink : MonoBehaviour {

	private float range = 0.05f;

	// Use this for initialization
	void Start () {
		this.transform.light.intensity = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (this.transform.light.intensity <= 0 ||
		    this.transform.light.intensity >= 8){
			range *= -1;
		}
		this.transform.light.intensity += range;
	}
}
