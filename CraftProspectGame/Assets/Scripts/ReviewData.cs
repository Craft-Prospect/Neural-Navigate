using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System;
using System.IO;
using System.Text;
using UnityEngine.SceneManagement;

public class ReviewData : MonoBehaviour {


	public void GetName(string nameinput){
        PlayerPrefs.SetString("newName", nameinput);

		string path = @"MyTest.txt";
		string addName = "Username: " + PlayerPrefs.GetString("newName","no name") + Environment.NewLine;
		// This text is added only once to the file.
		if (!File.Exists (path)) {
			File.WriteAllText (path, addName);
		} else {
			File.WriteAllText (path, addName);
		}
        
	}

	public void knowMoreSelected(string scene){
		string path = @"MyTest.txt";
		PlayerPrefs.SetString("knowMore","Yes");
		string email = PlayerPrefs.GetString("newEmail","N/A");
		string more = PlayerPrefs.GetString("knowMore","N/A");
		string addEmail = "Email: " + email + " Wants to know more?: " +more+ Environment.NewLine;
		// This text is added only once to the file.
		if (!File.Exists(path))
		{
			File.WriteAllText(path, addEmail);
		} else {
			File.AppendAllText (path, addEmail);
		}
		File.AppendAllText (path, Environment.NewLine);
		SceneManager.LoadScene (scene);
	}
		

	public void GetEmail(string email){
		PlayerPrefs.SetString ("newEmail", email);
	}

	public void GetReview(string review){
		string path = @"MyTest.txt";
		string addReview = "Review: " + review + Environment.NewLine;
		// This text is added only once to the file.
		if (!File.Exists(path))
		{
			File.WriteAllText(path, addReview);
		} else {
			File.AppendAllText (path, addReview);
		}
	}

	public void SystemGoodFor(string input){
		string path = @"MyTest.txt";
		string addInput = "Question 2 Results"+ Environment.NewLine+"What use for this feature detection could you think of: " +
			input + Environment.NewLine;
		// This text is added only once to the file.
		if (!File.Exists(path))
		{
			File.WriteAllText(path, addInput);
		} else {
			File.AppendAllText (path, addInput);
		}
	}

	public void DontUnderstand(string input){
		string path = @"MyTest.txt";
		string addInput =  "Question 2 Results"+ Environment.NewLine+
			"Why do you think this didn't help your understanding?: " + input + Environment.NewLine;
		// This text is added only once to the file.
		if (!File.Exists(path))
		{
			File.WriteAllText(path, addInput);
		} else {
			File.AppendAllText (path, addInput);
		}
	}
}
