using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStats : MonoBehaviour {

    private float _highscore;
    private int _experience;
    

    // MAKE THE PLAYERSTATS OBJECT A SINGLETON
    public static PlayerStats Instance;
    public void Awake()
    {
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
        PlayerPrefs.SetFloat("highscore", _highscore);
        PlayerPrefs.SetInt("experience", _experience);
        //PlayerPrefs.Save();

    }

    /// <summary>
    /// The players highscore
    /// </summary>
    public float Highscore
    {
        get { return _highscore; }
        set { _highscore = value; }
    }


    /// <summary>
    /// The players experience points
    /// </summary>
    public int Experience
    {
        get { return _experience; }
        set { _experience = value; }
    }

}
