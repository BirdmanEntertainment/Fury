using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MusicHandler : MonoBehaviour
{

    public AudioSource menu;
    public AudioSource gameplay;

    public float fadeRate = 0.01f;

    public static MusicHandler Instance;
    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (SceneManager.GetActiveScene().name == "titlescreen")
        {
            if (menu.isPlaying == false)
            {
                menu.Play();
            }

            if (menu.volume < 1)
            {
                menu.volume += fadeRate;
            }

            if (gameplay.volume > 0)
            {
                gameplay.volume -= fadeRate;
            } else if (gameplay.volume == 0)
            {
                gameplay.Stop();
            }
        }
        else if (SceneManager.GetActiveScene().name == "main")
        {
            if (gameplay.isPlaying == false)
            {
                gameplay.Play();
            }

            if (gameplay.volume < 1)
            {
                gameplay.volume += fadeRate;
            }

            if (menu.volume > 0)
            {
                menu.volume -= fadeRate;
            } else if (menu.volume == 0)
            {
                menu.Stop();
            }
        }
    }
}
