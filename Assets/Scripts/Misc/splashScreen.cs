using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class splashScreen : MonoBehaviour
{

    IEnumerator Start()
    {
        yield return new WaitForSeconds(3); // wait 2 seconds
        SceneManager.LoadScene("Scenes/titlescreen");
    }
}
