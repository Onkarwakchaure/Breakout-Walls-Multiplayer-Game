using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public Text ScoreText;
    public Text HighscoreText;

    public float ScoreCount;
    public float HighscoreCount;

    public float PonitsPerSecond;
    public bool ScoreIncreasing;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ScoreIncreasing)
        {
            ScoreCount += PonitsPerSecond * Time.deltaTime;

        }

        if (ScoreCount < HighscoreCount)
        {
            HighscoreCount = ScoreCount;
        }

        ScoreText.text = "Score : " + Mathf.Round  (ScoreCount);
        HighscoreText.text = "HighScore : " + Mathf.Round (HighscoreCount);
    }
}
