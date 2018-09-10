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

    public AudioSource click;

    Image progessbar;

    StreamReader reader;
    StreamWriter writer;

    public LevelControl levelControl;

    string minutes;
    string seconds;

    float highscore;
    float experience;
    int currentLevel = 1;
    float difference;


    const int EXP_CONSTANT = 300;
    float[] expReqArray = new float[51];


    void LoadData()
    {
        highscore = CloudVariables.time;
        experience = CloudVariables.experience;
        //Debug.Log("RETRIEVED DATA");
    }

    // Use this for initialization
    void Start()
    {
        //LoadData();

        previousExpText = GameObject.Find("PreviousLevelExp").GetComponent<Text>();
        nextExpText = GameObject.Find("NextLevelExp").GetComponent<Text>();
        currentExpText = GameObject.Find("CurrentLevelExp").GetComponent<Text>();

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
        //if (GPGDemo.Instance.GetCurrentUser() != "Uninitialized" && GPGDemo.Instance.GetCurrentUser() != "")
        //{
        //    usernameText.text = GPGDemo.Instance.GetCurrentUser();
        //    usernameObject.SetActive(true);
        //    signOutButton.SetActive(true);
        //    signInButton.SetActive(false);
        //}
        //else
        //{
        //    usernameObject.SetActive(false);
        //    signOutButton.SetActive(false);
        //    signInButton.SetActive(true);
        //}


    }

    public void ChangeScene(string sceneName)
    {
        click.Play();
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
