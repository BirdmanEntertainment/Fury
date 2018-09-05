using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class camerafollow : MonoBehaviour {

	public GameObject target;
	private Vector3 targetPos;
	private Vector3 mousePos;
	private Vector3 m_currentVelocity;


    public bool cameraShake = false;

    public float shakeAmount = 0.0f;

    public int maxSpeed;
	public float damping;
	public float offsetX, offsetY, offsetZ;


	//private bool mouseFollow;


	// Use this for initialization
	void Start () {
        //mouseFollow = false;
        //Time.fixedDeltaTime = 1 / 60f;
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if(target != null)
        {
            //mouseFollow = Input.GetButton("cam");
            targetPos = target.transform.position;
            targetPos.z = offsetZ;
            targetPos.x += offsetX;
            targetPos.y += offsetY;

            //if(mouseFollow){
            //	mousePos = Camera.main.WorldToViewportPoint(Input.mousePosition);
            //	mousePos.x /= 2;
            //	mousePos.y /= 2;
            //	mousePos.x += targetPos.x;
            //	mousePos.y += targetPos.y;

            //	mousePos.x -= 10;
            //	mousePos.y -= 10;
            //	mousePos.z = offsetZ;
            //	transform.position = Vector3.SmoothDamp(transform.position, mousePos, ref m_currentVelocity, damping, 1000, Time.deltaTime);
            //	//Debug.Log(targetPos);

            //}else{
            if(cameraShake)
            {
                targetPos.x += Random.Range(-shakeAmount, shakeAmount);
                targetPos.y += Random.Range(-shakeAmount, shakeAmount);
                targetPos.z += Random.Range(-shakeAmount, shakeAmount);
                
            }
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref m_currentVelocity, damping, maxSpeed, Time.deltaTime);

            //}
        } else
        {
            targetPos = new Vector3(0, 9.835f, -9.79f);
            transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref m_currentVelocity, damping, maxSpeed, Time.deltaTime);
        }


    }
}
