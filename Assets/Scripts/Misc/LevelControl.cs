using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;
using UnityEngine.Advertisements;

public class LevelControl : MonoBehaviour {

    public Image black;
    public Animator anim;

    Scene currentScene;

    public IEnumerator Fade(string levelName)
    {
        Debug.Log("FADE CALLED");
        anim.SetBool("Fade", true);

        if(SceneManager.GetActiveScene().name == "main" && levelName == "main")
        {
            int adChance = Random.Range(0, 5);

            if (adChance == 0)
            {
                Advertisement.Show();
            }
        }
        

        yield return new WaitUntil(() => black.color.a == 1);

        trafficCollision.crashed = false;

        SceneManager.LoadScene(levelName);

        // }
        //else if (direction == "In")
        //{
        //    anim.SetBool("Fade", false);
        //    yield return new WaitUntil(() => black.color.a == 0);
        //}
    }

    // Use this for initialization
    void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
