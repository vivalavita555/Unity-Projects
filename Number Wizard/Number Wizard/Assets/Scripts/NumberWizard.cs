using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class NumberWizard : MonoBehaviour
{
    int max = 1000;
    int min = 1;
    int guess = 500;
    // Start is called before the first frame update
    void Start()
    {
        StartGame();
    }

    void StartGame()
    {
        max = 1000;
        min = 1;
        guess = 500;

        Debug.Log("Y'awright cunt, this is Number Wizard");
        Debug.Log("Pick a fucking number between " + min + " and " + max);
        Debug.Log("Is your shitey wee number 500? (ENTER). Higher (UP) Lower (DOON)");
        max++;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            min = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            max = guess;
            NextGuess();
        }
        else if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Your shitey wee number was " + guess + "! Get fucked cunt");
        }

    }

    void NextGuess()
    {
        Debug.Log("Is it higher or lower than " + guess + "?");
        guess = (max + min) / 2;
    }
}

