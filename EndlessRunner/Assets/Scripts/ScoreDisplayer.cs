using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    public Text score;
    private int currentScore;
    private int calculateScore;
    
    // Start is called before the first frame update
    void Start()
    {
        score.text = "0";
        currentScore = 0;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 playerPos = GameObject.FindGameObjectWithTag("Player").transform.position;
        calculateScore = Mathf.FloorToInt((float)(playerPos.x + 7.5) / 10);
        
        if(int.Parse(score.text) < calculateScore) {
            score.text = calculateScore.ToString();
            currentScore = calculateScore;
        }
    }

    // check if score is new highscore and save if that is the case
    public void SaveHighscore() {
        if(PlayerPrefs.HasKey("Highscore")) 
        {
            if(PlayerPrefs.GetInt("Highscore") < currentScore) 
            {
                Debug.Log("Saved, already exists");
                PlayerPrefs.SetInt("Highscore", currentScore);
            }
        } 
        else PlayerPrefs.SetInt("Highscore", currentScore);

        PlayerPrefs.Save();
    }

}
