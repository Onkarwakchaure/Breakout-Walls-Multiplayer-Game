using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    public void LoadNextLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Finish")
        {
            UnlockNewLevel();
            GameManager.LevelCompleted = true;
            gameObject.SetActive(false);
        }
    }
    public void ReplayLevel()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
    void UnlockNewLevel()
    {
        if (SceneManager.GetActiveScene().buildIndex >= PlayerPrefs.GetInt("ReachedIndex"))
        {
            PlayerPrefs.SetInt("ReacheIndex", SceneManager.GetActiveScene().buildIndex+1);
            PlayerPrefs.SetInt("UnlockedLevel", PlayerPrefs.GetInt("Unlockedlevel", 1) +1);
            PlayerPrefs.Save();
        }
    }
}
