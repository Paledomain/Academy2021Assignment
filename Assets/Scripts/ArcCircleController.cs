using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArcCircleController : MonoBehaviour, Deletable
{
    //public GameObject arc1, arc2, arc3, arc4;
    GameObject player;
    bool isDeletable;

    //[Range(20, 200)]
    //public float maxDegreesPerSecond = 20;
    [Range(60, 200)]
    public float degreesPerSecond = 0;

    // Start is called before the first frame update
    void Start()
    {
        degreesPerSecond = Random.Range(20, 200);
        isDeletable = false;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);

       
    }

    public bool isDeletionOK()
    {
        return isDeletable;
    }

    public GameObject GetGameObject()
    {
        return this.gameObject;
    }
}
