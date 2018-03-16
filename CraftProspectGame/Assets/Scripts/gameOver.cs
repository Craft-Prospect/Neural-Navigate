using UnityEngine;
using UnityEngine.UI;
using System;

/*
 * Produces the appropriate Final game screen
 */
public class gameOver : MonoBehaviour {

	public Text gameOverText;
    public double score;

    void Start() {
        gameOverText.text = "Game Over!\n" + "Calculating your score using: \n" + Score.score.ToString() + "*" + Math.Round((ScoreManager.FeaturesDetected/ScoreManager.FeaturesPresented), 3) + "*" +  "0."+ GameObject.Find("GradeText").GetComponent<grade>().gradeText.text.Substring(3, 2) +  "\n" + 
            "Score = " + (Score.score * Math.Round((ScoreManager.FeaturesDetected / ScoreManager.FeaturesPresented), 3) * Int16.Parse(GameObject.Find("GradeText").GetComponent<grade>().gradeText.text.Substring(3, 2)) / 100).ToString("0") + "\n" + "\n" +
        "Thank you for playing, in order to better understand what you gained \n from playing our game please answer the following questions or click\n home to return to menu screen.";

        //Sets the players score
        score = (Score.score * Math.Round((ScoreManager.FeaturesDetected / ScoreManager.FeaturesPresented), 3) * Int16.Parse(GameObject.Find("GradeText").GetComponent<grade>().gradeText.text.Substring(3, 2)) / 100);
        PlayerPrefs.SetInt("newScore", (int)score);
        //Reset Player difficulty to Normal
        PlayerPrefs.SetInt("difficulty", 1);
    }
}
