using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System;

public class buttonManagerGameplay : MonoBehaviour
{

    public GameObject homeButton;
    public GameObject restartButton;
    public LevelControl levelcontrol_instance;

    Scene currentScene;

    void Awake()
    {
        currentScene = SceneManager.GetActiveScene();

        Button home_button = homeButton.GetComponent<Button>();
        Button restart_button = restartButton.GetComponent<Button>();

        home_button.onClick.AddListener(() => levelcontrol_instance.StartCoroutine("Fade", "Scenes/titlescreen"));
        restart_button.onClick.AddListener(() => levelcontrol_instance.StartCoroutine("Fade", currentScene.name));
    }
}
