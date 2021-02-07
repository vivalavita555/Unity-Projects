using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public GameObject gameOverText;
    public Text scoreText;
    public bool gameOver = false;
    public float scrollSpeed = -1.5f;
    private int score = 0;

    // Start is called before the first frame update

    //This function is using Singleton Design, meaning it makes the GameController all powerful over the project even if there's conflicting Objects for example Game Over being called elsewhere will be trumped by Game Over being called here
    void Awake() //Called BEFORE the Start() function, typically used when making Game Controllers
    {
        if(instance == null) //If no other Game Controllers exist
        {
            instance = this; //Use this Game Controller
        }
        else if (instance != this) //If our Game Controller isn't being used
        {
            Destroy(gameObject); //Destroys itself
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (gameOver == true && Input.GetMouseButtonDown(0))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex); //Restarts the game to the initial scene
        }
    }

    public void BirdScored()
    {
        if (gameOver)
        {
            return; //If Game is over don't even try to score a point
        }
        score++;
        scoreText.text = "Score: " + score.ToString(); //Sends the score to the ScoreText in the UI
            
    }
    public void BirdDied()
    {
        gameOverText.SetActive(true); //Unhides the GameOverText and the RestartText
        gameOver = true;
    }
}
