using UnityEngine;
using UnityEngine.UI;
using System;

/*
 * Calculates the grade
 * Sets the display color for the grade
 */
public class grade : gameOver {

	public Text gradeText;
	public float effeciencyRatio;
	// Use this for initialization
	void Awake (){
		effeciencyRatio = (ScoreManager.FeaturesDetected / ScoreManager.FeaturesPresented) * 100;
        string stringRatio = " (" + Math.Round((effeciencyRatio), 2).ToString() + "%)";
		switch ((int) Mathf.Floor(effeciencyRatio/10)) {
			case 10:
					gradeText.color = new Color(255.0f/255.0f, 236.0f/255.0f, 49.0f/255.0f);
                    gradeText.text = "S" + stringRatio;
					break;
		    case 9:
		 			gradeText.color = new Color(255.0f/255.0f, 236.0f/255.0f, 49.0f/255.0f);
                    gradeText.text = "S" + stringRatio;
					break;
			case 8:
					gradeText.color = new Color(50.0f/255.0f, 227.0f/255.0f, 23.0f/255.0f);
                    gradeText.text = "A" + stringRatio;
					break;
			case 7:
					gradeText.color = new Color(23.0f/255.0f, 227.0f/255.0f, 170.0f/255.0f);
                    gradeText.text = "B" + stringRatio;
					break;
			case 6:
				    gradeText.color = new Color(23.0f/255.0f, 201.0f/255.0f, 227.0f/255.0f);
                    gradeText.text = "C" + stringRatio;
					break;
			case 5:
					gradeText.color = new Color(208.0f/255.0f, 130.0f/255.0f, 10.0f/255.0f);
                    gradeText.text = "D" + stringRatio;
					break;
			case 4:
					gradeText.color = new Color(141.0f/255.0f, 11.0f/255.0f, 116.0f/255.0f);
                    gradeText.text = "E" + stringRatio;
					break;
			default:
					gradeText.color = new Color(216.0f/255.0f, 59.0f/255.0f, 20.0f/255.0f);
                    gradeText.text = "F" + stringRatio;
					break;
		}
	}

}
