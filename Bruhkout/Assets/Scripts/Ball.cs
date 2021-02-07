using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class Ball : MonoBehaviour


{
    public Text ScoreText;
    public int score;
    //Configuration Parameters
    [SerializeField] Paddle paddle;

    //State
    Vector2 paddleToBallVector;
    bool hasStarted = false;



    // Start is called before the first frame update
    void Start()
    {
        paddleToBallVector = transform.position - paddle.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (!hasStarted)
        {
            LockBallToPaddle();
        }

        LaunchOnMouseClick();
    }

    private void LockBallToPaddle()
    {
        Vector2 paddlePos = new Vector2(paddle.transform.position.x, paddle.transform.position.y);
        transform.position = paddlePos + paddleToBallVector;
    }

    private void LaunchOnMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(2f, 15f);
            hasStarted = true;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();

    }
 
    //private void HasScored()
    //{
    //    score++;
    //    ScoreText.text = "Score: " + score.ToString();
    //    Debug.Log(score);
    //    if (score == 63)
    //    {
    //        SceneManager.LoadScene(3);
    //    }
    //}
}
