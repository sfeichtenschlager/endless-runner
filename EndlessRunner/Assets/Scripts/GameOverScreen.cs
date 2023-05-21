using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverScreen : MonoBehaviour
{
    public Text pointsText; 
    public Text highscoreDisplay;

    public void Setup(int score)
    {
        gameObject.SetActive(true);
        pointsText.text = score.ToString() + " POINTS"; 
        highscoreDisplay.text = "Current Highscore: " + PlayerPrefs.GetInt("Highscore");
    }

    public void restartButton()
    {
        SceneManager.LoadScene("Scene01"); 
    }
}
