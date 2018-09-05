using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SensorCollision : MonoBehaviour {

    public bool hasDetected = false;
    public GameObject otherDetected;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Wall" || other.tag == "Traffic")
        {
            hasDetected = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        otherDetected = other.gameObject;
        hasDetected = false;
    }
}
