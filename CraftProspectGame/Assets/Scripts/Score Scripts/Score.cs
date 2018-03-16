using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : ScoreManager {

	public Text scoreText;
    public GameObject player;
    public static float score;
    public static float scoreAdd;
    public static float distancePreviousFrame;
	public static List<float> ratioList;
    private int frames = 0;

    /* Score is calculated by the players x postition and the time they take
     * */

	// Update is called once per frame
    void Update(){
        frames++;
        if (frames % 5 == 0) {
            ScoreUpdate();
            if (scoreAdd > 1)
            {
                score += scoreAdd;
                scoreAdd = 0;
            } 
        }
	}

    // called every 5 frames, for effeciency
    // updates scoreText to display latest score
    void ScoreUpdate(){
        score += Mathf.Abs(player.transform.position.x / 10 - distancePreviousFrame);
        distancePreviousFrame = Mathf.Abs(player.transform.position.x) / 10;
        scoreText.text = "Score: " + score.ToString("0");
    }

    // adds points to scoreAdd variable. Adds ratio of current/starting to ratioList
    // ratioList will be used in the end game to calculate an average and produce a grade. 
	public static void addWildfirePoints(float timeTaken, float current, float starting){
		if (timeTaken <= 1000) {
			scoreAdd += 1000 - timeTaken;
			ratioList.Add(current/starting);
		}
	}
}
