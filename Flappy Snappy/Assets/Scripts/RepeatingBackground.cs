using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatingBackground : MonoBehaviour
{
    private BoxCollider2D groundCollider;
    private float groundHorizontalLength;

    // Start is called before the first frame update
    void Start()
    {
        groundCollider = GetComponent<BoxCollider2D>();
        groundHorizontalLength = groundCollider.size.x; //Similar to how we recycled the Collider X to the position of Ground 2
    }

    // Update is called once per frame
    void Update()
    {
        if(transform.position.x < -groundHorizontalLength) //If the position of the background exceeds the lenght of the background...
        {
            RepositionBackground(); 
        }
    }

    private void RepositionBackground()
    {
        Vector2 groundOffset = new Vector2(groundHorizontalLength * 2f, 0); //Background is offset seamlessly
        transform.position = (Vector2)transform.position + groundOffset;
    }
}
