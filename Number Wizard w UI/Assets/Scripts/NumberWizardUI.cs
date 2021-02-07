using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;
using UnityEngine.SceneManagement;

public class NumberWizardUI : MonoBehaviour
{

    [SerializeField]int max = 1000;
    [SerializeField]int min = 1;
    [SerializeField]TextMeshProUGUI guessText;

    int guess = 500;

    // Start is called before the first frame update
    void Start()
    {
        int currentScene = SceneManager.GetActiveScene().buildIndex;

        if (currentScene == 1)
        {
            StartGame();
        }
    }

   

    void StartGame()
    {
        guess = (max + min) / 2;
        guessText.text = guess.ToString();
        max++;
    }

    public void OnPressHigher()
        {
            min = guess;
            NextGuess();
        }
    public void OnPressLower()
        {
            max = guess;
            NextGuess();
        }

    void NextGuess()
    {
        guess = (max + min) / 2;
        guessText.text = guess.ToString();
    }
}

