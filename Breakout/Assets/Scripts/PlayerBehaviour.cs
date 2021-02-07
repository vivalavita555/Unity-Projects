using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.XR;

public class PlayerBehaviour : MonoBehaviour
{
    public float maxPos = 4.23f;
    public float resetPos = 4.22f;
    public float playerVel =0.1f;
    private UnityEngine.Vector2 playerPos;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = gameObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {

        //horizontal movement
        playerPos.x += Input.GetAxis("Horizontal") * playerVel;
        
        //update the game object transform
        transform.position = playerPos;

        //boundary
        if (playerPos.x < -maxPos)
        {
            playerPos.x = -maxPos;
        }

        if(playerPos.x > maxPos)
        {
            playerPos.x = maxPos;
        }
    }
}
