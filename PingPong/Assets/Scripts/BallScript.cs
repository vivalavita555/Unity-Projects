using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScript : MonoBehaviour
{
    [SerializeField] Vector2 startSpeed = new Vector2(5, 5);    //Initial direction of the ball
    [SerializeField] float topBoundary = 4.0f;                  //Bottom of the play area
    [SerializeField] float bottomBoundary = -4.0f;              //Top of the play area
    [SerializeField] float leftBoundary = -8.5f;                //Just behind Player 1's paddle
    [SerializeField] float rightBoundary = 8.5f;                //Just behind Player 2's paddle
    [SerializeField] AudioClip hitSound;                        //The sound that plays when the ball bounces on a wall or paddle
    [SerializeField] AudioClip scoreSound;                      //The sound that plays when a player scores

    // Variables that will be used to store:
    int player1Score = 0;       // * player 1's score
    int player2Score = 0;       // * player 2's score
    Rigidbody2D body;           // * a reference to the ball's RigidBody
    AudioSource soundSource;    // * a reference to the ball's AudioSource


    private void OnGUI()
    {
        //Set the texture for score to the Ball's texture
        Texture ballSprite = GetComponent<SpriteRenderer>().sprite.texture;
        int startX = 15;
        int spacing = 55;

        // Iteration to draw one 'ballSprite' for each point
        // of player 1's score.
        for (int i = 0; i < player1Score; i++)
        {
            GUI.DrawTexture(new Rect(startX, 15, 40, 40), ballSprite);
            startX += spacing;
        }

        //Negate spacing so it goes in the opposite direction for Player 2
        spacing = -55;
        startX = Screen.width + spacing;
        // Iteration to draw one 'ballSprite' for each point
        // of player 2's score.
        for (int i = 0; i < player2Score; i++)
        {
            GUI.DrawTexture(new Rect(startX, 15, 40, 40), ballSprite);
            startX += spacing;
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // TODO: Play 'hitsound' through the soundSource.
        soundSource.PlayOneShot(hitSound);
    }

    // Start is called before the first frame update
    void Start()
    {
        soundSource = GetComponent<AudioSource>();      //Set a variable to represent the Ball's AudioSource component
        body = GetComponent<Rigidbody2D>();             //Set a variable to represent the Ball's RigidBody2D component
        SpawnBall(1);                                   //Spawn the ball and shoot Right
    }

    //Spawn the ball, take in a direction which is (-1) Left or (+1) Right
    void SpawnBall(int direction)
    {
        body.transform.position = new Vector3(0, 0, 0);     //Reset the Ball's position
        body.velocity = (startSpeed * direction);           //Set the new direction for the Ball
    }

    // Update is called once per frame
    void Update()
    {
        //If the ball hits either the Top or Bottom of the play area...
        if (body.position.y >= topBoundary || body.position.y <= bottomBoundary)
        {
            startSpeed.y *= -1; //...negate the Y value of the Ball (change direction)
        }
        //If the ball goes past Player 2's paddle
        else if (body.position.x >= rightBoundary)
        {
            player1Score++;                             //Increment the Player 1's Score by 1
            soundSource.PlayOneShot(scoreSound);        //Play the Score audio file
            SpawnBall(-1);                              //When the ball spawns it will move towards the previous winner, in this case Player 1 - Left
        }
        //If the ball goes past Player 1's paddle
        else if (body.position.x <= leftBoundary)
        {
            player2Score++;                             //Increment Player 2's Score by 1
            soundSource.PlayOneShot(scoreSound);        //Play the Score audio file
            SpawnBall(1);                               //When the ball spawns it will move towards the previous winner, in this case Player 2 - Right
        }
        //If a player has 5 points, they win and the game ends
        if (player1Score >= 5 || player2Score >= 5)
        {
            body.Sleep();
        }
    }
}
