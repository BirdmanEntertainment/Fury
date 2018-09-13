using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spawner : MonoBehaviour
{

    Vector3 spawnLocationTraffic;
    Vector3 spawnLocationRain;

    Vector3 lampSpawnLocationLeft;
    Vector3 lampSpawnLocationRight;

    public GameObject traffic;
    public GameObject token;
    public GameObject raindrop;

    //public GameObject obstacleLampSingle;
    const float SPAWN_Y = 0.5f;
    const float SPAWN_Z = 150f;
    const int RAIN_AMOUNT = 5;

    int trafficCount = 0;

    const int MAX_TRAFFIC = 6;

    float[] trafficRangeArray = new float[7] { -7.4f, -4.93f, -2.46f, 0, 2.46f, 4.93f, 7.4f };

    float frameCount = 0;

    // Use this for initialization
    void Start()
    {
        Time.fixedDeltaTime = 1/60f;

        spawnLocationTraffic = new Vector3(0, SPAWN_Y, SPAWN_Z);
        spawnLocationRain = new Vector3(0, 0, 25f);

        lampSpawnLocationLeft = new Vector3(-9f, 0.0f, SPAWN_Z);
        lampSpawnLocationRight = new Vector3(9f, 0.0f, SPAWN_Z);

        spawnLocationTraffic.x = trafficRangeArray[Random.Range(0, trafficRangeArray.Length)];
        Instantiate(traffic, spawnLocationTraffic, Quaternion.Euler(0, 180, 0));

        //for (int i = 0; i < RAIN_AMOUNT; i++)
        //{
        //    spawnLocationRain.z = ((i * 3) + 1) * (25 / RAIN_AMOUNT);
        //    Debug.Log("SPAWN LOCATION Z = " + spawnLocationRain.z);
        //    spawnLocationRain.x = Random.Range(-2f, 2f);
        //    spawnLocationRain.y = 0f;
        //    Instantiate(raindrop, spawnLocationRain, Quaternion.Euler(90, 0, 0));
        //    spawnLocationRain.z = 25f;
        //}
    }

    void SpawnToken()
    {
        Instantiate(token, new Vector3(trafficRangeArray[Random.Range(0, trafficRangeArray.Length)], 1, spawnLocationTraffic.z), Quaternion.Euler(0, 0, 0));
    }

    // Update is called once per frame
    void Update()
    {
        frameCount = Time.frameCount;

        if(frameCount % Random.Range(120, 240) == 0)
        {
            SpawnToken();
        }

        if (frameCount % 120 == 0 && trafficCount != MAX_TRAFFIC)
        {
            
            //spawnLocationTraffic.z += trafficRangeArray[Random.Range(0, trafficRangeArray.Length)] * 3;
            spawnLocationTraffic.x = trafficRangeArray[Random.Range(0, trafficRangeArray.Length)];
            Instantiate(traffic, spawnLocationTraffic, Quaternion.Euler(0, 180, 0));
            trafficCount++;
            spawnLocationTraffic.z = SPAWN_Z;
        }

    }
}
