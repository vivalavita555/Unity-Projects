using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    public float upForce = 200f; //Represents how high the Bird jumps

    private bool isDead = false;
    private Rigidbody2D rb2d;
    private Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D> (); //Stores the value of Rigidbody2D in the object Bird
        anim = GetComponent<Animator>(); //Stores the current animation value
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead == false)
        {
            if (Input.GetMouseButtonDown (0)) //If LMB is clicked
            {
                rb2d.velocity = Vector2.zero; //Vector2 represents 2D positions and vectors ('2' meaning 2 values stored x,y), everytime the player jumps the velocity is reset to zero
                rb2d.AddForce(new Vector2 (0, upForce)); //0 because the player doesn't move horizontally in this game, only vertically represented by upForce
                anim.SetTrigger("Flap");
            }
        }
    }

    void OnCollisionEnter2D()
    {
        rb2d.velocity = Vector2.zero;
        isDead = true;
        anim.SetTrigger("Die");
        GameControl.instance.BirdDied(); //instantiation using the Game Controller
    }
}
