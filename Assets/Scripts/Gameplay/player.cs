using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{

    public int moveSpeed;
    float direction = 0;
    float angle = 0;

    private Rigidbody rbody;

    public bool touchInput;

    Vector3 touchPos;

    const float SMOOTH_AMOUNT = 10f; // Higher = Less Smoothing
    const float BOUNDARY = 8.5f;

    // Use this for initialization
    void Start()
    {
        
        rbody = GetComponent<Rigidbody>();
    }

    /// <summary>
    /// Move the player based on a value
    /// </summary>
    void Move(float dir)
    {

        direction = Mathf.Lerp(direction, dir, SMOOTH_AMOUNT * Time.deltaTime);
        angle = Mathf.Lerp(angle, dir * 20, SMOOTH_AMOUNT * Time.deltaTime);

        transform.Translate(direction / moveSpeed, 0f, 0f, Space.World);
        //transform.Translate(new Vector3(direction / moveSpeed, 0f, 0f), Space.World);
        transform.localRotation = Quaternion.Euler(0, angle, -angle/2);

        if (transform.position.x > BOUNDARY)
        {
            transform.position = new Vector3(BOUNDARY, transform.position.y, transform.position.z);
        }
        else if (transform.position.x < -BOUNDARY)
        {
            transform.position = new Vector3(-BOUNDARY, transform.position.y, transform.position.z);
        }

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (touchInput && !trafficCollision.crashed)
        {
            if (Input.touchCount > 0)
            {

                Touch touch = Input.GetTouch(0);

                if (touch.position.x < Screen.width / 2)
                {
                    Move(-1);
                }
                else if (touch.position.x > Screen.width / 2)
                {
                    Move(1);
                }

            }
            else
            {
                Move(0);
            }

        }
        else if (!touchInput && !trafficCollision.crashed)
        {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                Move(1);
            } else if (Input.GetKey(KeyCode.LeftArrow))
            {
                Move(-1);
            } else
            {
                Move(0);
            }
        }

        if (transform.position.z < -8)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

}

