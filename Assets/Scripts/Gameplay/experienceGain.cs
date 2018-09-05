using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class experienceGain : MonoBehaviour
{


    float time;
    float currentExp;
    float expGain = 0;
    float combinedExp;

    bool expAdded = false;

    Text expGainText;

    public GameObject expObject;

    // Use this for initialization
    void Start()
    {
        InvokeRepeating("IncreaseExp", 1, 1);

        //currentExp = CloudVariables.experience;
        expGainText = expObject.GetComponent<Text>();
    }

    void IncreaseExp()
    {
        expGain += 10;
        //Debug.Log(expGain);
    }

    void AddToTotal()
    {
        expAdded = true;
        Debug.Log("CALLED EXP ADD - " + combinedExp);
        //if(combinedExp > CloudVariables.experience)
        //{
        //    CloudVariables.experience = combinedExp;
        //    GPGDemo.Instance.SaveData();
        //}
        DisplayExp();
    }

    void DisplayExp()
    {
        try
        {
            Debug.Log(expGain);
            expGainText.text = "+" + expGain;
        } catch (Exception ex)
        {
            Debug.Log(ex);
        }
    }

    // Update is called once per frame
    void Update()
    {
        combinedExp = currentExp + expGain;

        if(trafficCollision.crashed)
        {
            if (!expAdded)
            {
                CancelInvoke();
                AddToTotal();
            }
        }
    }
}
