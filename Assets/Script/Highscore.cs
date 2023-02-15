using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text highscore;
    private int scoreNumber;

    // Start is called before the first frame update
    void Start()
    {
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
        scoreNumber = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            scoreNumber++;
            highscore.text = "Highscore: " + scoreNumber.ToString();
            PlayerPrefs.SetInt("Highscore", scoreNumber);
        }
    }
}
