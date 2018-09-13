using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class rotate : MonoBehaviour {

    private float angle = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        angle++;
        transform.localRotation = Quaternion.Euler(0, angle, 0);
	}
}
