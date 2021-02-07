using System.Collections;
using System.Collections.Generic;

using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    private bool ballIsActive;
    private Vector2 ballPos;
    private Vector2 ballInitialForce;
    public GameObject playerObject;

    // Start is called before the first frame update
    void Start()
    {
        //create the force
        ballInitialForce = new Vector2(100f, 300f);
        ballIsActive = false;
        ballPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // check for user input
        if (Input.GetButtonDown("Jump") == true)
        {
            // check if is the first play
            if (!ballIsActive)
            {
                // add a force
                Rigidbody2D rb = GetComponent<Rigidbody2D>();
                rb.AddForce(ballInitialForce);
                // set ball active
                ballIsActive = !ballIsActive;
            }
        }

        if(!ballIsActive && playerObject != null)
        {
            ballPos.x = playerObject.transform.position.x;
            transform.position = ballPos;
        }

        if(ballIsActive && transform.position.y < -6)
        {
            ballIsActive = !ballIsActive;
            ballPos.x = playerObject.transform.position.x;
            ballPos.y = 4.2f;
            transform.position = ballPos;
            Rigidbody2D rb = GetComponent<Rigidbody2D>();
            rb.isKinematic = true;
        }
    }
}
