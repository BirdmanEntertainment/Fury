using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camera : MonoBehaviour {

    
    //public GameObject player;

    float move;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {

        move = Input.acceleration.x;

        transform.Translate(move / 4, 0.0f, 0.0f, Space.World);
        if(transform.position.x > 6.1)
        {
            transform.position = new Vector3(6.1f, transform.position.y, transform.position.z);
        } else if (transform.position.x < -6.1)
        {
            transform.position = new Vector3(-6.1f, transform.position.y, transform.position.z);
        }
	}
}
