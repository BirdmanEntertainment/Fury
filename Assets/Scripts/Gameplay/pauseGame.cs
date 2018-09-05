using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pauseGame : MonoBehaviour {

    public bool isPaused = false;


    public void setPaused()
    {
        
        isPaused = !isPaused;

        if(isPaused)
        {
            Time.timeScale = 0;
        } else
        {
            Time.timeScale = 1;
        }
        
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        
	}
}
