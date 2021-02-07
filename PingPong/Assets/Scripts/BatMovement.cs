using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatMovement : MonoBehaviour
{
    [SerializeField] KeyCode upKey = KeyCode.W;     //Set the variable upKey to the KeyCode for 'W'     (As this is 'Serialized' Player 2 can utilise the 'P' key)
    [SerializeField] KeyCode downKey = KeyCode.S;   //Set the varibale downKey to the KeyCode for 'S'   (As this is 'Serialized' Player 2 can utilise the 'L' key)
    [SerializeField] Vector2 batSpeed;
    [SerializeField] float topBoundary;
    [SerializeField] float bottomBoundary;
    Rigidbody2D batBody;

    // Start is called before the first frame update
    void Start()
    {
        batBody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(upKey))
            batBody.AddForce(batSpeed);
        if (Input.GetKey(downKey))
            batBody.AddForce(-batSpeed);
        if (transform.position.y > topBoundary)
            transform.position = new Vector3(transform.position.x, topBoundary);
        if (transform.position.y < bottomBoundary)
            transform.position = new Vector3(transform.position.x, bottomBoundary);
    }
}
