using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class MusicHandler : MonoBehaviour
{

    public AudioSource menu;
    public AudioSource gameplay;

    [Range (0, 1)]
    public float mainVolume;

    public float fadeRate = 0.01f;

    // MAKE THE MUSICHANDLER A SINGLETON ---
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
    // --------------------------------------

    void Start()
    {
        if(PlayerPrefs.HasKey("mainVolume"))
        {
            mainVolume = PlayerPrefs.GetFloat("mainVolume");
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        AudioListener.volume = mainVolume;
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
