using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitcherController : MonoBehaviour, Deletable
{

    public GameObject switcherDot; //colour switcher's dot

    Transform switcherPos; //switcher's transform

    [Range(4, 2000)]
    public float maxDegreesPerSecond = 20;
    float degreesPerSecond = 4;
    bool spinBanner = true;
    bool isDeletable;


    // Start is called before the first frame update
    void Start()
    {
        switcherPos = switcherDot.transform;//shortcut for switcher transform
        isDeletable = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (degreesPerSecond < maxDegreesPerSecond && spinBanner)
            degreesPerSecond += 10;
        if (degreesPerSecond >= maxDegreesPerSecond)
        {
            spinBanner = false;
        }
        if (degreesPerSecond > 1 && !spinBanner)
        {
            degreesPerSecond -= 5;
        }
        if (degreesPerSecond <= 1 && !spinBanner)
            spinBanner = true;
            

        //print(degreesPerSecond + " " + spinBanner);
        switcherPos.Rotate(new Vector3(0, 0, degreesPerSecond) * Time.deltaTime);
    }


    void OnTriggerEnter2D(Collider2D otherCollider)
    {
        //Debug.Log("Trigger1");
        if (otherCollider.tag == "Player")
        {
            //Debug.Log("Trigger2");
            int currentColour = otherCollider.gameObject.GetComponent<PlayerController>().GetColour();
            int[] validColours;
            int index;

            if (currentColour == 1)
            {
                validColours = new int[] { 2, 3, 4 };
                index = Random.Range(0, validColours.Length);
                currentColour = validColours[index];
            }
            else if (currentColour == 2)
            {
                validColours = new int[] { 1, 3, 4 };
                index = Random.Range(0, validColours.Length);
                currentColour = validColours[index];
            }
            else if (currentColour == 3)
            {
                validColours = new int[] { 1, 2, 4 };
                index = Random.Range(0, validColours.Length);
                currentColour = validColours[index];
            }
            else if (currentColour == 4)
            {
                validColours = new int[] { 1, 2, 3 };
                index = Random.Range(0, validColours.Length);
                currentColour = validColours[index];
            }

            otherCollider.gameObject.GetComponent<PlayerController>().ChangeColours(currentColour);
            isDeletable = true;
        }

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
