using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms.Impl;
using UnityEngine.UI;

public class Level : MonoBehaviour
{
    public Text ScoreText;
    static int score;
    [SerializeField] int breakableBlocks; //Serialized for debugging purposes

    //Cached referenced
    SceneLoader sceneLoader;
    public void CountBreakableBlocks()
    {
        breakableBlocks++;
    }

    public void BlockDestroyed()
    {
        breakableBlocks--;
        if (breakableBlocks <= 0)
        {
            SceneManager.LoadScene(3);
        }
        score++;
        ScoreText.text = "SCORE: " + score.ToString();
        PlayerPrefs.SetInt("score", score);
    }
}
