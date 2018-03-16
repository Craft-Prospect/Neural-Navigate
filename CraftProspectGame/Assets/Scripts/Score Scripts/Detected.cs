using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class Detected : ScoreManager {

	public Text detectedText;

	//UI text for detected ratio
	void Update () {
        detectedText.text = (Math.Round((FeaturesDetected/FeaturesPresented), 3) * 100).ToString() + "%";
	}
}
