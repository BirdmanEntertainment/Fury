using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setText : MonoBehaviour {

    Text text;

	// Use this for initialization
	void Start () {
        text = this.GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //Debug.Log(score.minutes + ":" + score.seconds);
        text.text = score.minutes + ":" + score.seconds;
	}
}
