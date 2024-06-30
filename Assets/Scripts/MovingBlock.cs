using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MovingBlock : MonoBehaviour
{
    [SerializeField] float moveSpeed = 3f;
    float startingYPosition;
    public static int Score;
    public static int HighScore;

    void Start()
    {
        startingYPosition = transform.position.y;
        Score = 0;
        HighScore = PlayerPrefs.GetInt("HighScore");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += Vector3.left * Time.deltaTime * moveSpeed;
        if (transform.position.x <= -10)
        {
            transform.position += Vector3.right * 30f;
            float newY = startingYPosition + UnityEngine.Random.Range(-1f, 1f);
            transform.position = new Vector3(transform.position.x, newY, 0f);
            Score++;
            if (Score > HighScore)
            {
                HighScore = Score;
                PlayerPrefs.SetInt("HighScore", Score);
            }
        }

    }
}