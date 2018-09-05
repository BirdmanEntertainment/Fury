using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fpsCount : MonoBehaviour {

	// Use this for initialization
	void Start () {
        //Debug.Log(Application.targetFrameRate);
        //QualitySettings.vSyncCount = 0;
        Application.targetFrameRate = 80;
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(1.0f / Time.deltaTime);

	}
}
