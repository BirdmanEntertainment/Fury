using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

    private AudioSource coinPickup;

	// Use this for initialization
	void Start () {
        coinPickup = Camera.main.GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        transform.Translate(0, 0, -1.2f, Space.World);

        if (transform.position.z < -8)
        {
            GameObject.Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            PlayerStats.Instance.Tokens++;
            GameObject.Destroy(this.gameObject);
            coinPickup.Play();
        }
    }
}
