using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class parallax : MonoBehaviour
{

    Vector3 vecParallax;
    float filter = 5.0f;

    float degreesX;
    float degreesY;
    float degreesZ;

    Vector3 angle;

    public AudioSource click;

    public float remap(float value, float low1, float high1, float low2, float high2)
    {
        return low2 + (value - low1) * (high2 - low2) / (high1 - low1);
    }

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

    // Update is called once per frame
    void Update()
    {
        vecParallax = Vector3.Lerp(vecParallax, Input.acceleration / 2, filter * Time.deltaTime);

        vecParallax.z = this.transform.position.z;
        this.transform.position = vecParallax;

        angle = Vector3.Lerp(angle, new Vector3(degreesX, degreesY, degreesZ), filter * Time.deltaTime);
        this.transform.localRotation = Quaternion.Euler(angle);

    }
}
