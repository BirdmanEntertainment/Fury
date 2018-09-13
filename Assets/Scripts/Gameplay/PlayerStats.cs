using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System;

public class PlayerStats : MonoBehaviour {


    public static StatItem highscore;
    public static StatItem experience;
    public List<StatItem> statItemList = new List<StatItem>();
    

    // MAKE THE PLAYERSTATS OBJECT A SINGLETON
    public static PlayerStats Instance;
    public void Awake()
    {
        highscore = new StatItem("highscore", 0);
        experience = new StatItem("experience", 0);
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
        foreach (StatItem s in statItemList)
        {
            try
            {   
                s.Content = PlayerPrefs.GetFloat(s.Key);
            } 
            catch(Exception ex)
            {
                PlayerPrefs.SetFloat(s.Key, s.Content);
            }
            
        }
        
        //Debug.Log("CALLED LOAD DATA");
        // if (PlayerPrefs.HasKey("highscore"))
        // {
        //     _highscore = PlayerPrefs.GetFloat("highscore");
        // }
        // else
        // {
        //     PlayerPrefs.SetFloat("highscore", 0);
        // }

        // if (PlayerPrefs.HasKey("experience"))
        // {
        //     _experience = PlayerPrefs.GetInt("experience");
        // }
        // else
        // {
        //     PlayerPrefs.SetInt("experience", 0);
        // }
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
        foreach (StatItem s in statItemList)
        {
            PlayerPrefs.SetFloat(s.Key, s.Content);
        }

        PlayerPrefs.Save();

        // PlayerPrefs.SetFloat("highscore", _highscore.Key);
        // PlayerPrefs.SetInt("experience", _experience);
        //PlayerPrefs.Save();

    }

}
