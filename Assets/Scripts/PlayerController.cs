using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float jumpForce = 1;

    //public GameObject playerDot; //player's physics dot
    public GameObject deathJuice; //player's death particle effects
    
    [Range(1,4)]
    public int playerColour = 1; //player's colour

    Transform playerPos; //player's transform
    Vector3 screenPos; //player's transform wrt to screen space
    Camera cam;
    Rigidbody2D rb;

    public bool alive = true;

    public bool IsAlive()
    {
        if (alive)
            return true;
        return false;
    }
    public void SetAlive(bool liveliness)
    {
        alive = liveliness;
    }

    public int ChangeColours (int col)
    {
        if (col == 1)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
            playerColour = col;
        }
        else if (col == 2)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            playerColour = col;
        }
        else if (col == 3)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.red);
            playerColour = col;
        }
        else if (col == 4)
        {
            GetComponent<Renderer>().material.SetColor("_Color", Color.green);
            playerColour = col;
        }
        return col;
    }

    public int GetColour()
    {
        return playerColour;
    }

    // Start is called before the first frame update
    void Start()
    {
        playerPos = transform;//shortcut for player transform
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();//main cam finder
        rb = GetComponent<Rigidbody2D>();//shortcut for player rigidbody
        playerColour = 1;
    }

    // Update is called once per frame
    void Update()
    {
        if(alive)//if alive
        {

            if (Input.GetMouseButtonDown(0))//jump the player dot
            {
                rb.gravityScale = 90;
                rb.velocity = new Vector3(rb.velocity.x, 0);
                rb.AddForce(transform.up * jumpForce);
            }

            screenPos = cam.WorldToScreenPoint(playerPos.position);//see where dot pos is on screen

            if (screenPos.y <= 0)//player dot leaves screen
            {
                KillCommand();
            }
            //print(playerColour);
        }
        else//if dead
        {
            KillCommand();
        }
    }

    private void FixedUpdate()
    {
    }

    public void KillCommand()
    {
        if (alive)
        {
            deathJuice.SetActive(true);
            GetComponent<SpriteRenderer>().enabled = false;
            rb.gravityScale = 0;
            rb.velocity = Vector2.zero;
            alive = false;
            Invoke(nameof(Kill), 2.0f);
        }

    }

    void Kill()
    {
        GameController.playerAlive = false;
        //Destroy(this.gameObject);
        gameObject.SetActive(false);
    }

    public void ResurrectCommand()
    {
        if (!alive)
        {
            gameObject.SetActive(true);
            deathJuice.SetActive(false);
            GameController.playerAlive = true;
            alive = true;

            GetComponent<SpriteRenderer>().enabled = true;
            gameObject.transform.position = Vector3.zero;

            rb.velocity = Vector2.zero;

            //rb.Sleep();

        }

    }

}
