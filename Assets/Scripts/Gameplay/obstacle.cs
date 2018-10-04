using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class obstacle : MonoBehaviour
{
    Transform tr;

    string objTag = "";

    float trafficSpeed = -1.2f;
    float obstacleSpeed = -1.5f;
    float rainSpeed = -1.5f;

    const float SPAWN_Z = 250f;
    Vector3 newSpawnLocationTraffic;
    Vector3 newSpawnLocationRain;
    float[] trafficRangeArray = new float[7] { -7.38f, -4.92f, -2.46f, 0, 2.46f, 4.92f, 7.38f };

    bool isTraffic = false;
    bool isRain = false;

    Vector3 moveV;

    // Use this for initialization
    void Start()
    {
        //Time.fixedDeltaTime = 1 / 60f;

        //trafficSpeed += Random.Range(-0.3f, 0.3f);

        tr = this.transform;
        objTag = this.tag;

        newSpawnLocationTraffic = new Vector3(0.0f, 0.5f, SPAWN_Z);
        newSpawnLocationRain = new Vector3(0.0f, 0.0f, 25f);

        if (objTag == "Traffic")
        {
            moveV = new Vector3(0.0f, 0.0f, trafficSpeed);
            isTraffic = true;
            isRain = false;
        }
        else if (objTag == "Raindrop")
        {
            moveV = new Vector3(0.0f, 0.0f, rainSpeed);
            isRain = true;
            isTraffic = false;
        }
        else
        {
            moveV = new Vector3(0.0f, 0.0f, obstacleSpeed);
        }


    }

    // Update is called once per frame
    void FixedUpdate()
    {
        tr.position += moveV;
        //transform.Translate(-moveV);

        if (tr.position.z < -50)
        {
            if (isTraffic)
            {
                //newSpawnLocationTraffic.z;// += trafficRangeArray[Random.Range(0, trafficRangeArray.Length)] * 30;
                newSpawnLocationTraffic.x = trafficRangeArray[Random.Range(0, trafficRangeArray.Length)];
                this.transform.position = newSpawnLocationTraffic;
                newSpawnLocationTraffic.z = SPAWN_Z;
            } else if (isRain)
            {
                newSpawnLocationRain.x = Random.Range(-2f, 2f);
                newSpawnLocationRain.y = Random.Range(5f, 10f);
                this.transform.position = newSpawnLocationRain;

            }
        }
    }
}
