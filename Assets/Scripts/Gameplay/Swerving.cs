using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swerving : MonoBehaviour
{

    Vector3 currentPos;
    Vector3 newPos;
    Vector3 pos;

    public GameObject rightBox;
    public GameObject leftBox;
    public GameObject frontBox;

    SensorCollision rightDetector;
    SensorCollision leftDetector;
    SensorCollision frontDetector;

    bool swerveInitiated = false;
    bool locked = false;

    const float SMOOTHING = 3f;

    int swerveChance;
    float angle = 0;

    bool rightDetected;
    bool leftDetected;
    bool frontDetected;

    // Use this for initialization
    void Start()
    {

        rightDetector = rightBox.GetComponent<SensorCollision>();
        leftDetector = leftBox.GetComponent<SensorCollision>();
        frontDetector = frontBox.GetComponent<SensorCollision>();

        InvokeRepeating("RandomSwerve", 1, 1);
        pos = this.transform.position;

        angle = 180;
    }

    void RandomSwerve()
    {
        swerveChance = Random.Range(0, 2);
        Debug.Log(swerveChance);
    }

    void Swerve()
    {
        swerveInitiated = true;
        newPos = currentPos;
        Debug.Log("CALLED");
        if (rightDetected && !leftDetected)
        {
            newPos.x -= 2.46f;
        }
        else if (!rightDetected && leftDetected)
        {
            newPos.x += 2.46f;
        }
        else if (rightDetected && leftDetected)
        {
            this.transform.SetParent(frontDetector.otherDetected.transform);
        }
        else
        {
            if (Random.Range(0, 2) == 0)
            {
                newPos.x += 2.46f;
            }
            else
            {
                newPos.x -= 2.46f;
            }
        }


    }

    IEnumerator StopSwerving()
    {
        yield return new WaitForSeconds(4f);
        swerveInitiated = false;
    }

    // Update is called once per frame
    void Update()
    {
        currentPos = this.transform.position;

        rightDetected = rightDetector.hasDetected;
        leftDetected = leftDetector.hasDetected;
        frontDetected = frontDetector.hasDetected;

        Debug.Log("RIGHT - " + rightDetected);
        Debug.Log("LEFT - " + leftDetected);


        if (swerveChance == 1 && !swerveInitiated && !locked)
        {
            Swerve();
            StartCoroutine("StopSwerving");
        }

        if (swerveInitiated)
        {
            pos = Vector3.Lerp(currentPos, newPos, SMOOTHING * Time.deltaTime);
            angle = 180;
            angle += (newPos.x - currentPos.x) * 3;

        }

        pos.z = this.transform.position.z;

        this.transform.position = pos;

        this.transform.localRotation = Quaternion.Euler(0.0f, angle, 0.0f);
    }
}
