using UnityEngine;

public class Energy : MonoBehaviour {

	public static bool energyEnabled = false;
	public static float startingHealth;
	public static float currentHealth;

	
	// Update is called once per frame
    /* 
        Once space bar is pressed, the energyEnabled value changes, if 
        true the energy decreases down to a value of 0, if false the energy regenerates 
        until it's equal to startingHealth.
    */
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space))
        {
			energyEnabled = true;
		}
        if (Input.GetKeyUp(KeyCode.Space))
        {
            energyEnabled = false;
        }
       
        if (energyEnabled && currentHealth > 0) {
			currentHealth -= Time.deltaTime;
			currentHealth = Mathf.Clamp(currentHealth, 0 , startingHealth);
			transform.localScale = new Vector3((currentHealth/startingHealth),1,1);
		}
		else if (!energyEnabled && currentHealth < startingHealth) {
			currentHealth += Time.deltaTime;
			currentHealth = Mathf.Clamp(currentHealth, 0, startingHealth);
			transform.localScale = new Vector3((currentHealth/startingHealth),1,1);
		}
	}

	public static float getCurrentHealth() {
		return currentHealth;
	}

	public static float getStartingHealth() {
		return startingHealth;
	}
}
