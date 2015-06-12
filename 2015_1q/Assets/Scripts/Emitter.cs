﻿using UnityEngine;
using System.Collections;

public class Emitter : MonoBehaviour {

    public GameObject[] waves;
    private int currentWave;
    private Manager manager;

    IEnumerator Start()
    {
        Debug.Log(1231);
        if (waves.Length == 0)
        {
            yield break;
        }
        manager = FindObjectOfType<Manager>();
        while (true) {
            while (manager.IsPlaying() == false)
            {
                yield return new WaitForEndOfFrame();
            }
            GameObject wave = (GameObject)Instantiate(waves[currentWave], transform.position, transform.rotation);
            wave.transform.parent = transform;
            while (wave.transform.childCount != 0)
            {
                yield return new WaitForEndOfFrame();
            }
            Destroy(wave);

            if (waves.Length <= ++currentWave)
            {
                currentWave = 0;
            }
        }
	}
}
