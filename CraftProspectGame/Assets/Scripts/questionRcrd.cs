using UnityEngine;
using System.Linq;
using System;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

/**
 * Records the answer to a question
 */

public class questionRcrd : MonoBehaviour {

	public void Question1_yes(string sceneName){
		int score = PlayerPrefs.GetInt ("question1Yes", 0);
		score += 1;
		PlayerPrefs.SetInt ("question1Yes", score);
		string path = @"MyTest.txt";
		string addResult = "Question 1 Results"+ Environment.NewLine+"Did this game aid your understanding of our neural net" +
			" Yes: " + PlayerPrefs.GetInt("question1Yes",0);
		string addResult2 = " No: " + PlayerPrefs.GetInt("question1No",0) + Environment.NewLine;
		// This text is added only once to the file.
		if (!File.Exists (path)){
			File.WriteAllText (path, addResult);
		} else{
			File.AppendAllText (path, addResult);
		}
		File.AppendAllText (path, addResult2);
		SceneManager.LoadScene (sceneName);
	}

	public void Question1_no(string sceneName){
		int score = PlayerPrefs.GetInt ("question1No", 0);
		score += 1;
		PlayerPrefs.SetInt ("question1No", score);
		string path = @"MyTest.txt";
		string addResult = "Question 1 Results (Did this game aid your understanding of our neural net" +
			") Yes: " + PlayerPrefs.GetInt("question1Yes",0) + Environment.NewLine;
		string addResult2 = "No: " + PlayerPrefs.GetInt("question1No",0) + Environment.NewLine;
		// This text is added only once to the file.
		if (!File.Exists (path)){
			File.WriteAllText (path, addResult);
		} else {
			File.AppendAllText (path, addResult);
		}
		File.AppendAllText (path, addResult2);
		SceneManager.LoadScene (sceneName);
	}
}
