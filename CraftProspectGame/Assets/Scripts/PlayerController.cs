using System.Collections.Generic;
using UnityEngine;
using System;

/* Script sets behaviour of the player character:
 * difficulty is set depending on the choice set by playerpref on the main menu
 * xScroll forces the player to move and is faster on higher difficulties
 * each frame the players new location is calculated based on their input + the base horizontal side scrolling movement 'xScroll'
 * */
public class PlayerController : MonoBehaviour {

	public float MAX_SPEED = 10f;
	public float FALLOFF_CLOUD = 1f;
	public float FALLOFF_AIR = 1f;
    public float topBorder = -20f;
    public float bottemBorder = -72f;
    public float xScroll = 0f;
    private float xv = 0.0f;
	private float yv = 0.0f;
    private bool isInCloud = false;
	private float cloudSpeed = 5.0f;
	private float normalSpeed = 5f;

    void Start(){
        List<float> difficultySpeed = new List<float>();
        difficultySpeed.Add(.2f);
        difficultySpeed.Add(.3f); 
        difficultySpeed.Add(0.5f);
        xScroll = difficultySpeed[PlayerPrefs.GetInt("difficulty")];
    }

    void Update (){
		// move based on player input
		float fo = (isInCloud ? FALLOFF_CLOUD : FALLOFF_AIR);
		//float x = Input.GetAxis("Horizontal") * Time.deltaTime * (isInCloud ? cloudSpeed : normalSpeed);
		float y = Input.GetAxis("Vertical") * Time.deltaTime * (isInCloud ? cloudSpeed : normalSpeed);
		//xv += x; xv *= fo; xv = clamp(xv);
		yv += y; yv *= fo; yv = clamp(yv);
        yv *= 0.95f;
        if (transform.position.y > topBorder)
            transform.Translate(xScroll * 0.35f, -1f, 0);
        else if (transform.position.y < bottemBorder)
            transform.Translate(xScroll * 0.35f, 1f, 0);
        else transform.Translate(xScroll, yv*fo , 0);
	}

	public void setInCloud(){ isInCloud = true; }
	public void setNotInCloud(){ isInCloud = false; }

	private float clamp(float v){
		if(Math.Abs(v) > MAX_SPEED){
			v = Math.Sign(v) * MAX_SPEED;
		}
		return v;
	}
}
