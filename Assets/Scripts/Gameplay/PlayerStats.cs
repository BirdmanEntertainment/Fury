using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerStats : MonoBehaviour {

    private float _highscore;
    private int _experience;
    private int _tokens;
    

    // MAKE THE PLAYERSTATS OBJECT A SINGLETON
    public static PlayerStats Instance;
    public void Awake()
    {
        _highscore = 0;
        _experience = 0;
        _tokens = 0;

        LoadData();
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
    // -----------------------------------------------

    /// <summary>
    /// Loads the players statistics
    /// </summary>
    private void LoadData()
    {
        Debug.Log("CALLED LOAD DATA");
        if (PlayerPrefs.HasKey("highscore"))
        {
            _highscore = PlayerPrefs.GetFloat("highscore");
        }
        else
        {
            PlayerPrefs.SetFloat("highscore", 0);
        }

        if (PlayerPrefs.HasKey("experience"))
        {
            _experience = PlayerPrefs.GetInt("experience");
        }
        else
        {
            PlayerPrefs.SetInt("experience", 0);
        }

        if (PlayerPrefs.HasKey("tokens"))
        {
            _tokens = PlayerPrefs.GetInt("tokens");
        }
        else
        {
            PlayerPrefs.SetInt("tokens", 0);
        }
    }

    /// <summary>
    /// Clears the Players statistics
    /// </summary>
    public void Clear()
    {
        PlayerPrefs.DeleteAll();
    }

    /// <summary>
    /// Save the Players statistics
    /// </summary>
    public void SaveData()
    {
        // Set each playerpref to the respective variable stored
        PlayerPrefs.SetFloat("highscore", _highscore);
        PlayerPrefs.SetInt("experience", _experience);
        PlayerPrefs.SetInt("tokens", _tokens);
        PlayerPrefs.Save();

    }

    // The players highscore
    public float Highscore
    {
        get { return _highscore; }
        set { _highscore = value; }
    }

    // The players total experience points
    public int Experience
    {
        get { return _experience; }
        set { _experience = value; }
    }

    // The players total number of Tokenss
    public int Tokens
    {
        get { return _tokens; }
        set { _tokens = value; }
    }
}
