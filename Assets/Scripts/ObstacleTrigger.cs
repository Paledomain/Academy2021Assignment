using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleTrigger : MonoBehaviour
{

    public bool obstTriggered;//whether a player dot has crossed through this obstacle
    public int playerColour;//what the touching player's colour number is (int)
    // Start is called before the first frame update
    [Range(1,4)]
    public int obstacleColour;


    void Start()
    {
        obstTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (obstacleColour ==1)
            GetComponent<Renderer>().material.SetColor("_Color", Color.magenta);
        if (obstacleColour == 2)
            GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
        if (obstacleColour == 3)
            GetComponent<Renderer>().material.SetColor("_Color", Color.red);
        if (obstacleColour == 4)
            GetComponent<Renderer>().material.SetColor("_Color", Color.green);
    }

    private void OnTriggerEnter2D(Collider2D otherCollider)
    {
        if (otherCollider.tag == "Player")
        {
            obstTriggered = true;
            playerColour = otherCollider.gameObject.GetComponent<PlayerController>().GetColour();

            if(playerColour != obstacleColour)
            {
                otherCollider.GetComponent<PlayerController>().KillCommand();
            }
        }
    }

    public bool GetPlayerContact()
    {
        return obstTriggered;
    }

    public void SetPlayerContact(bool contact)
    {
        obstTriggered = contact;
    }

    public int GetPlayerColour()
    {
        return playerColour;
    }
}
