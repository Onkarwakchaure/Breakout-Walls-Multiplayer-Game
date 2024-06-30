using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public SceneFader sceneFader;
    public string Game = "Game";
    public void PlayGame()
    {
        sceneFader.FadeTo(Game);
    }
    public void QuitGame()
    {
        Debug.Log("Quitting Game...!");
        PlayerPrefs.Save();
        Application.Quit();
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        PlayerPrefs.Save();
        SceneManager.LoadScene("Menu");
    }

    public void LoadMP()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Loading sc");
    }
}
