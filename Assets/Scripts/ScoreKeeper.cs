using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreKeeper : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TextMeshProUGUI scoreText = gameObject.GetComponent<TextMeshProUGUI>();

        scoreText.text = "" + GameController.gameScore;
    }
}
