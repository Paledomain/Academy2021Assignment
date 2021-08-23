using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour
{
    public static int gameScore;
    public static int highScore;
    public static bool playerAlive;
    public GameObject player;
    Camera cam;

    public GameObject[] obstacleList;
    public GameObject star;
    public GameObject switcher;

    public GameObject[] switchList; //the list that has the switch in it
    public GameObject[] noSwitchList; //the list that does not have the switch in it

    GameObject spawnedObject;
    GameObject objectToSpawn;

    List<Deletable> objectList;


    [Range(101, -101)]
    float horzDisplacement;//horizontal displacement for obstacles
    public Vector3 spawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        gameScore = 0;
        highScore = 0;
        playerAlive = true;
        cam = GameObject.Find("Main Camera").GetComponent<Camera>();//main cam finder

        objectList = new List<Deletable>();

        //spawn starter objects
        SpawnObject();
        SpawnObject();
        SpawnObject();
       

    }

    // Update is called once per frame
    void Update()
    {

        ResetValues();

        if(playerAlive)
        {
            //print(spawnPosition.y - player.transform.position.y);

            if(spawnPosition.y - player.transform.position.y < 900)
            {
                SpawnObject();
            }

        }

        for (int i = 0; i < objectList.Count; i++)
        {
            if (player.transform.position.y - objectList[i].GetGameObject().transform.position.y > 900 || objectList[i].isDeletionOK())
            {
                Destroy(objectList[i].GetGameObject());
                objectList.RemoveAt(i);
                i--;
            }
        }

    }

    private void ResetValues()
    {
        if (!playerAlive)
        {
            spawnPosition = Vector3.zero;
            if (Input.GetMouseButtonDown(0))
            {
                //purge existing items
                for (int i = 0; i < objectList.Count; i++)
                {
                    Destroy(objectList[i].GetGameObject());
                }
                objectList.Clear();

                //record high score
                highScore = Mathf.Max(highScore, gameScore);

                //restart game
                //Instantiate(player, new Vector3(0, 0, 0), Quaternion.identity);
            
                gameScore = 0;
                player.GetComponent<PlayerController>().ResurrectCommand();
                
            }
        }   
    }

    void SpawnObject()
    {
        int index;
        if (spawnedObject != switcher)
        {
            index = Random.Range(0, switchList.Length); //use the list that does not have the colour switcher in it
            objectToSpawn = switchList[index];
        }
        else
        {
            index = Random.Range(0, noSwitchList.Length); //use the list that has the colour switcher in it
            objectToSpawn = noSwitchList[index];
        }


        

        if(objectToSpawn.CompareTag("obstacle"))
        {
            horzDisplacement = Random.Range(40, 100);
            if (horzDisplacement < 4)
            {
                horzDisplacement = Random.Range(-40, -100);
            }

            spawnPosition = new Vector2(horzDisplacement, spawnPosition.y + 300);
        }
        else
        {
            spawnPosition = new Vector2(0, spawnPosition.y + 300);
        }

        spawnedObject = objectToSpawn;
        GameObject tempObject = Instantiate(objectToSpawn, spawnPosition, Quaternion.identity);
        objectList.Add(tempObject.GetComponent<Deletable>());
    }
}
