using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour, Deletable
{
    public GameObject starJuice; //star collection particle effects
    public GameObject star;
    bool isDeletable;

    // Start is called before the first frame update
    void Start()
    {
        isDeletable = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        GameController.gameScore += 1;
        //starJuice.SetActive(true);
        Instantiate(starJuice, transform.position, Quaternion.identity);
        starJuice.transform.localScale = new Vector3(30, 30, 30);
        star.SetActive(false);
        //Invoke("Kill", 2.0f);
        isDeletable = true;
    }

    public bool isDeletionOK()
    {
        return isDeletable;
    }
    public GameObject GetGameObject()
    {
        return this.gameObject;
    }

    /*void Kill()
    {
        Destroy(this.gameObject);
    }*/
}
