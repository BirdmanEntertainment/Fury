using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class policelight : MonoBehaviour {


    bool redActive = false;
    bool blueActive = true;

    public GameObject redlight;
    public GameObject bluelight;

    public GameObject redshadow;
    public GameObject blueshadow;

    // Use this for initialization
    void Start () {
        redlight.SetActive(redActive);
        bluelight.SetActive(blueActive);

        redshadow.SetActive(redActive);
        blueshadow.SetActive(blueActive);
    }
	
	// Update is called once per frame
	void Update () {
        if (Time.frameCount % 60 == 0)
        {
            if (redshadow != null)
            {
                blueActive = !blueActive;
                redActive = !redActive;

                redlight.SetActive(redActive);
                bluelight.SetActive(blueActive);

                redshadow.SetActive(redActive);
                blueshadow.SetActive(blueActive);
            }
        } 
	}
}
