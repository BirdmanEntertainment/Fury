using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using UnityEngine.SceneManagement;

public class score : MonoBehaviour
{
    StreamWriter writer;
    StreamReader reader;

    public GameObject UICanvas;
    public GameObject EndGame;
    public GameObject HighScoreText;

    public static float timeSurvived;
    public static string minutes;
    public static string seconds;

    public LevelControl levelControl;

    int adChance;
    //float currentHS = 0;

    bool aboveThirty = false;
    bool aboveMinute = false;

    bool endCalled = false;

    // Use this for initialization
    void Start()
    {
        Time.fixedDeltaTime = 1 / 60f;
        UICanvas.SetActive(true);
        EndGame.SetActive(false);
        HighScoreText.SetActive(false);
    }

    void SetHighScore()
    {
        Debug.Log("SCORE SET");

        if (timeSurvived > PlayerStats.Instance.Highscore)
        {
            PlayerStats.Instance.Highscore = timeSurvived;
            PlayerStats.Instance.SaveData();
            //GPGDemo.Instance.OnAddScoreToLeaderBoard(Mathf.RoundToInt(timeSurvived) * 1000, GPGSIds.leaderboard_time);
            HighScoreText.SetActive(true);
        }

    }

    private void GameFinished()
    {
        endCalled = true;
        Debug.Log("END CALLED");
        SetHighScore();
    }


    // Update is called once per frame
    void FixedUpdate()
    {
        if (trafficCollision.crashed)
        {

            UICanvas.SetActive(false);
            EndGame.SetActive(true);
            if (!endCalled)
            {
                GameFinished();
            }
        }
        else
        {
            timeSurvived = Mathf.Round(Time.timeSinceLevelLoad);

            minutes = Mathf.Floor(timeSurvived / 60).ToString("00");
            seconds = (timeSurvived % 60).ToString("00");

            if (timeSurvived >= 30 && !aboveThirty)
            {
                aboveThirty = true;
                //GPGDemo.Instance.UnlockAchievement(GPGSIds.achievement_thirty_second_samurai);
            }

            if (timeSurvived >= 60 && !aboveMinute)
            {
                aboveMinute = true;
                //GPGDemo.Instance.UnlockAchievement(GPGSIds.achievement_minute_man);
                
            }
        }
    }
}
