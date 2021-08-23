using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class recordKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI recordText = gameObject.GetComponent<TextMeshProUGUI>();

        recordText.text = "" + GameController.highScore;
    }
}
