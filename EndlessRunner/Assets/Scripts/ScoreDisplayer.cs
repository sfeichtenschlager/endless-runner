using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreDisplayer : MonoBehaviour
{
    public Text score;
    private int currentScore;
    
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
        int calculateScore = Mathf.FloorToInt((float)(playerPos.x + 7.5) / 10);
        
        if(int.Parse(score.text) < calculateScore) {
            score.text = calculateScore.ToString();
            currentScore = calculateScore;
        }
    }

}
