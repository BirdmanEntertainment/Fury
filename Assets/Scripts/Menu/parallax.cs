using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class parallax : MonoBehaviour
{

    Vector3 vecParallax;
    Vector3 vecParallaxLerped;
    float filter = 5.0f;

    float degreesX;
    float degreesY;
    float degreesZ;

    Vector3 angle;

    public AudioSource click;

    // Use this for initialization
    void Start()
    {
        //Time.fixedDeltaTime = 1 / 60f;
        degreesX = 0;
        degreesY = 0;
        degreesZ = 0;
        
    }

    public void rotateCamX(int degX)
    {
        click.Play();
        degreesX = degX;
        
    }

    public void rotateCamY(int degY)
    {
        click.Play();
        degreesY = degY;
        
    }

    public void rotatecamZ(int degZ)
    {
        click.Play();
        degreesZ = degZ;
        
    }

    public void translatecamX(int dist)
    {
        click.Play();
        
    }

    // Update is called once per frame
    void Update()
    {
        vecParallax = new Vector3(Input.acceleration.x, Input.acceleration.y + 1, Input.acceleration.z);

        vecParallaxLerped = Vector3.Lerp(vecParallaxLerped, Input.acceleration, filter * Time.deltaTime);

        vecParallaxLerped.z = this.transform.position.z;
        this.transform.localPosition = vecParallaxLerped;

        angle = Vector3.Lerp(angle, new Vector3(degreesX, degreesY, degreesZ), filter * Time.deltaTime);


        this.transform.localRotation = Quaternion.Euler(angle);

    }
}
