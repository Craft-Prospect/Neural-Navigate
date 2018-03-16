using UnityEngine;

/*
 * Feature represents a feature on the map
 */
public class Feature : Score {
    
	public GameObject feature; 
	public float timeOnEntered; //time when player touches feature
	public float timeTakenToDetect; //time when player detects feature

    //player enters feature collider
	void OnTriggerEnter2D(Collider2D other){
		timeOnEntered = Time.time * 1000;
	}

    // calculates time taken for player to detect feature once player is inside the feature 

	void OnTriggerStay2D(Collider2D other){
		// trigger when satellite stays in WildFire
		if (Energy.energyEnabled == true && Energy.currentHealth > 0) {
            Timer.addTime(5);
			timeTakenToDetect = (Time.time * 1000) - timeOnEntered;
			Score.addWildfirePoints(timeTakenToDetect, getCurrentHealth(), getStartingHealth());
            Destroy(feature);
			ScoreManager.SetFeaturesDetected(1);
		}
	}

    // destroys feature when off screen
	void OnBecameInvisible() {
        Destroy(feature);
    }

    void OnBecameVisible() {
        ScoreManager.SetFeaturesPresented(1);
    }
}
