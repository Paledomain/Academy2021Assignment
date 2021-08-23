using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    GameObject player;
    bool playerFound = false;
    Transform playerPos; //player's transform
    Vector3 screenPos; //player's transform wrt to screen space
    Camera cam;

    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponent<Camera>();
        GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
        if(objects.Length > 0)
        {
            player = objects[0];
            playerPos = player.transform;
            playerFound = true;
        }
            
    }
    // Update is called once per frame
    void Update()
    {

        if (!GameController.playerAlive)
        {
            playerFound = false;
            cam.transform.position = new Vector3(0, 0, -1);
        }

        else if (GameController.playerAlive && !playerFound)
        {
            GameObject[] objects = GameObject.FindGameObjectsWithTag("Player");
            if (objects.Length > 0)
            {
                player = objects[0];
                playerPos = player.transform;
                playerFound = true;
            }
        }

        else if (GameController.playerAlive && playerFound && player.transform != null)
        {
            screenPos = cam.WorldToScreenPoint(playerPos.position);
        }


        if (screenPos.y > (cam.pixelHeight / 2))
        {
            cam.transform.position = new Vector3(cam.transform.position.x, playerPos.position.y, cam.transform.position.z);
            //print("playerY: " + screenPos.y + "and screenTriggerY: " + (cam.pixelHeight / 2));
        }
    }
}
