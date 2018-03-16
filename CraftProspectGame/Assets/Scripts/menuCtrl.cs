using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections.Generic;


/*
 * General use script for methods needed in multiple scenes, such as difficulty setting and scene changing
 */
public class menuCtrl : MonoBehaviour{

    public static menuCtrl Instance { set; get; }

	public void LoadScene(string sceneName) {
        if (sceneName == "Playing") {
            ReloadGameVariables();
            SceneManager.LoadScene("Playing");
        } else {
            SceneManager.LoadScene(sceneName); 
        }
	}

    void setEasy()
    {
        PlayerPrefs.SetInt("difficulty", 0);
    }

    void setNormal()
    {
        PlayerPrefs.SetInt("difficulty", 1);
    }

    void setRealistic()
    {
        PlayerPrefs.SetInt("difficulty", 2);
    }

    void ReloadGameVariables()
    {
        //Timer
        Timer.timeLeft = 25;
        //Difficulty Starting Health
        if (PlayerPrefs.GetInt("difficulty") == 0){
            Energy.startingHealth = 3;
        }
        else if (PlayerPrefs.GetInt("difficulty") == 1){
            Energy.startingHealth = 2;
        }
        else{
            Energy.startingHealth = 1;
        }
        Energy.currentHealth = Energy.startingHealth;

        //Score load
        Score.score = 0;
        Score.scoreAdd = 0;
        Score.distancePreviousFrame = 0;
        Score.ratioList = new List<float>();

        //Scoremanager features detected and presented
        ScoreManager.FeaturesDetected = 0;
        ScoreManager.FeaturesPresented = 0;
    }
}
