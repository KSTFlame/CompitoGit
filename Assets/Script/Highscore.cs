using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{

    public Text highscore;
    private int score;

    // Start is called before the first frame update
    void Start()
    {
        highscore.text = "Highscore: " + PlayerPrefs.GetInt("Highscore").ToString();
        score = PlayerPrefs.GetInt("Highscore");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            score++;
            highscore.text = "Highscore: " + score.ToString();
            PlayerPrefs.SetInt("Highscore", score);
        }
    }
}
