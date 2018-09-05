using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class buttonManager : MonoBehaviour {

    public GameObject signInButton;
    public GameObject leaderboardButton;
    public GameObject achievementButton;
    public GameObject signoutButton;

    void Awake()
    {
        Button signin_button = signInButton.GetComponent<Button>();
        Button leaderboard_button = leaderboardButton.GetComponent<Button>();
        Button achievement_button = achievementButton.GetComponent<Button>();
        Button signout_button = signoutButton.GetComponent<Button>();


        //signin_button.onClick.AddListener(() => GPGDemo.Instance.LogIn());
        //leaderboard_button.onClick.AddListener(() => GPGDemo.Instance.OnShowLeaderBoard());
        //achievement_button.onClick.AddListener(() => GPGDemo.Instance.ShowAchievementUI());
        //signout_button.onClick.AddListener(() => GPGDemo.Instance.OnLogOut());
    }
}
