﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;



public class trafficCollision : MonoBehaviour {

    public static bool crashed = false;

    public AudioSource explosion;

    void Start () {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            explosion.Play();
            //Debug.Log("test");
            other.transform.SetParent(this.gameObject.transform);
            crashed = true;
        }
    }
}
