using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightning : MonoBehaviour
{

    int flashChance = 0;

    public AudioSource thunderclap;

    public GameObject lightning1;
    public GameObject lightning2;
    public GameObject lightning3;
    public GameObject lightning4;
    public GameObject flashLight;

    // Use this for initialization
    void Start()
    {
        
    }

    IEnumerator flash(GameObject lightning, GameObject light)
    {
        //Debug.Log(lightning);
        lightning.SetActive(true);
        light.SetActive(true);
        yield return new WaitForSeconds(0.05f); // wait 2 seconds
        lightning.SetActive(false);
        light.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (lightning1 != null &&
            lightning2 != null &&
            lightning3 != null &&
            lightning4 != null &&
            flashLight != null)
        flashChance = Random.Range(0, 500);
        if (flashChance == 1)
        {
            //Debug.Log("CALLED");
            thunderclap.Play();
            StartCoroutine(flash(lightning1, flashLight));
            
        }
        else if (flashChance == 2)
        {
            thunderclap.Play();
            StartCoroutine(flash(lightning2, flashLight));
        }
        else if (flashChance == 3)
        {
            thunderclap.Play();
            StartCoroutine(flash(lightning3, flashLight));
        }
        else if (flashChance == 4)
        {
            thunderclap.Play();
            StartCoroutine(flash(lightning4, flashLight));
        }
    }
}
