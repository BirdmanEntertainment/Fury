using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sineMovement : MonoBehaviour {

    float val = 0;
    float sineValue = 0;
    public float speed = 0.0f;

    float initialX;
    float initialY;
    float initialZ;

    float initialRotX;
    float initialRotY;
    float initialRotZ;


    public bool rotate = false;

	// Use this for initialization
	void Start () {
        initialX = transform.position.x;
        initialY = transform.position.y;
        initialZ = transform.position.z;
        initialRotX = transform.localRotation.x;
        Debug.Log(initialRotX);
        initialRotY = transform.localRotation.y;
        Debug.Log(initialRotY);
        initialRotZ = transform.localRotation.z;
        Debug.Log(initialRotZ);
        //Time.fixedDeltaTime = 1 / 60f;
    }
	
	// Update is called once per frame
	void Update () {
        val += speed;

        sineValue = Mathf.Sin(val);

        transform.localPosition = new Vector3(initialX, initialY, initialZ + sineValue);
        transform.localRotation = Quaternion.Euler(initialRotX, initialRotY + (sineValue * 2), initialRotZ + (sineValue * 2));

        if(rotate)
        {
            transform.localRotation = Quaternion.Euler(0, sineValue * 30, 0);
        }
	}
}
