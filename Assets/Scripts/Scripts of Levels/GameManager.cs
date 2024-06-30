using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class GameManager : MonoBehaviour
{
    public static bool LevelCompleted;
    public static bool GameOver;
    public GameObject LevelCompletedScreen;
    public GameObject GameOverScreen;

    private void Awake()
    {
        LevelCompleted = false;
        GameOver = false;
    }

    void Update()
    {
        if (LevelCompleted)
        {
            LevelCompletedScreen.SetActive(true);
        }

        if (GameOver)
        {
            GameOverScreen.SetActive(true);
        }
    }

}
