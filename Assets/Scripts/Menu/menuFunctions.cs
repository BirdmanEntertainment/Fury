using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using System.IO;


public class menuFunctions : MonoBehaviour
{
    GameObject usernameObject;
    GameObject signInButton;
    GameObject signOutButton;

    Text scoreText;
    Text usernameText;
    Text levelText;
    Text previousExpText;
    Text nextExpText;
    Text currentExpText;
    Text tokensText;

    Image progessbar;

    StreamReader reader;
    StreamWriter writer;

    public LevelControl levelControl;

    string minutes;
    string seconds;

    float highscore;
    int experience;
    int currentLevel = 1;
    float difference;


    const int EXP_CONSTANT = 300;
    int[] expReqArray = new int[51];


    void LoadData()
    {
        highscore = PlayerStats.Instance.Highscore;
        experience = PlayerStats.Instance.Experience;
        Debug.Log("RETRIEVED DATA - " + highscore + "," + experience);
    }

    // Use this for initialization
    void Start()
    {
        LoadData();

        previousExpText = GameObject.Find("PreviousLevelExp").GetComponent<Text>();
        nextExpText = GameObject.Find("NextLevelExp").GetComponent<Text>();
        currentExpText = GameObject.Find("CurrentLevelExp").GetComponent<Text>();
        tokensText = GameObject.Find("TokensText").GetComponent<Text>();

        expReqArray[0] = 0;


        for (int i = 1; i < expReqArray.Length; i++)
        {
            expReqArray[i] = expReqArray[i - 1] + (int)(EXP_CONSTANT * 3.0f);

            if (experience > expReqArray[i])
            {
                currentLevel++;

            }

        }

        if (experience > expReqArray[expReqArray.Length - 1])
        {
            currentLevel = 50;
        }

        difference = Mathf.InverseLerp(expReqArray[currentLevel - 1], expReqArray[currentLevel], experience);

        usernameObject = GameObject.Find("UserText");
        signInButton = GameObject.Find("SignInButton");
        signOutButton = GameObject.Find("SignOutButton");

        progessbar = GameObject.Find("Bar").GetComponent<Image>();
        scoreText = GameObject.Find("ScoreText").GetComponent<Text>();
        levelText = GameObject.Find("LevelText").GetComponent<Text>();
        //usernameText = usernameObject.GetComponent<Text>();



        string minutes = Mathf.Floor(highscore / 60).ToString("00");
        string seconds = (highscore % 60).ToString("00");

        scoreText.text = "Local Best Time - " + minutes + ":" + seconds;
        tokensText.text = PlayerStats.Instance.Tokens.ToString();
        levelText.text = currentLevel.ToString();

        progessbar.fillAmount = difference;

        previousExpText.text = expReqArray[currentLevel - 1] + "xp";
        nextExpText.text = expReqArray[currentLevel] + "xp";
        currentExpText.text = experience + "xp";

        //GPGDemo.Instance.SaveData();
    }
    // Update is called once per frame
    void Update()
    {

    }

    public void ChangeScene(string sceneName)
    {
        levelControl.StartCoroutine("Fade", sceneName);
        //SceneManager.LoadScene(sceneName);
    }

    public void OpenLink(string link)
    {
        Application.OpenURL(link);
    }

    public void CloseApplication()
    {
        Application.Quit();
    }
}
