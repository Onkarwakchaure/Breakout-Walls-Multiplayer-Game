using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public SceneFader sceneFader;

    public string Game = "Game";
    public void RestartGame()
    {
        Time.timeScale = 1f;
        sceneFader.FadeTo(Game);
    }
    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Enemy")
        {
            GameManager.GameOver = true;
            gameObject.SetActive(false);
        }
    }

}
