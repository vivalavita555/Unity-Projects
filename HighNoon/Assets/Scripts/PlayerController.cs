using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{

    //Player Stats
    private int health = 3;
    [SerializeField] AudioClip deathSound;
    [SerializeField] GameObject PlayerWinText;
    //Player Movement
    [SerializeField] KeyCode upKey = KeyCode.W;
    [SerializeField] KeyCode downKey = KeyCode.S;
    [SerializeField] KeyCode shootKey = KeyCode.Space;
    [SerializeField] float lowerBoundary = -2.7f;
    [SerializeField] float upperBoundary = 3.7f;
    [SerializeField] float playerSpeed = 0.1f;
    //Bullet Prefab
    [SerializeField] GameObject bulletPrefabReference;
    [SerializeField] float bulletSpeed = 20f;
    [SerializeField] private Transform bulletSpawnLocation;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        health--;
        if (health <= 0)
        {
            GetComponent<AudioSource>().PlayOneShot(deathSound);
            Destroy(gameObject, 1f);
            Text winTextComponent = PlayerWinText.GetComponent<Text>();
            if (gameObject.name == "Player1") // if player 1 has been killed
            {
                winTextComponent.text = "Player 2 wins!";
            }
            else                             // or player 2 has been killed
            {
                winTextComponent.text = "Player 1 wins!";
            }
            PlayerWinText.SetActive(true);
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Bullet Shot
        if (Input.GetKeyDown(shootKey))
        {
            Vector3 spawnPoint = bulletSpawnLocation.position;
            Quaternion bulletRotation = Quaternion.identity;
            GameObject bullet = Instantiate(bulletPrefabReference, spawnPoint, bulletRotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(bulletSpeed, 0); //x = units p/s
            Destroy(bullet, 2f);
            AudioSource playerSound = GetComponent<AudioSource>();
            playerSound.Play();
        }

        //Player Movement
        if (Input.GetKey(upKey) && transform.position.y <= upperBoundary)
        {
            transform.position += new Vector3(0, playerSpeed, 0);
        }   
        if (Input.GetKey(downKey)&& transform.position.y >= lowerBoundary)
        {
            transform.position -= new Vector3(0, playerSpeed, 0);
        }
    }
}
