using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/*Script is used for game timer:
 * While time is not 0 counter decreases a second at a time
 * At 0 the final score is saved and the post game scene is loaded
 */
public class Timer : MonoBehaviour{
	public static int timeLeft;
	public Text countdownText;
	public string scene = "Game_over";
    public GameObject player;
    public static float score;

    // Use this for initialization
    void Start(){
		StartCoroutine("LoseTime");
	}

	// Update is called once per frame
	void Update(){
		countdownText.text = ("Time Left = " + timeLeft);

		if (timeLeft <= 0){
			StopCoroutine("LoseTime");
			countdownText.text = "Times Up!";
            score = Mathf.Abs(player.transform.position.x * 10);
            PlayerPrefs.SetInt("newScore", (int)score);
            LoadScene(scene);
		}
	}

	IEnumerator LoseTime(){
		while (true)
		{
			yield return new WaitForSeconds(1);
			timeLeft--;
		}
	}

	public void LoadScene(string sceneName){
		SceneManager.LoadScene (sceneName);
	}

    public static void addTime(int time){
        timeLeft += time;
    }

}
