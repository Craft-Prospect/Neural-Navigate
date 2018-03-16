using UnityEngine;
using UnityEngine.UI;


public class leaderBoard : MonoBehaviour {


    public int newScore;
    public Text[] highScores;
    public int[] highScoreInts;
    public string[] highScoreNames;

    /*Script saves player Highscores - top scores are kept and ranked with new high scores pushing them out accordingly
     * Scores are saved as 'PlayerPrefs' with top scores added to a list
     * This list is iterated through to check if a new score is a high score
     * If it is the new score is added and the score below it are pushed down
     * After ranking is calculated the scores are drawn and the list saved
     * DelScores() can be used to reset list to blank
     * */

	// Use this for initialization
	void Start () {
        highScoreInts = new int[highScores.Length];
        highScoreNames = new string[highScores.Length];

        for (int x = 0; x < highScoreInts.Length; x++)
        {
            highScoreInts[x] = PlayerPrefs.GetInt("highScoreInts" + x);
            highScoreNames[x] = PlayerPrefs.GetString("highScoreNames" + x);
        }
        drawScores();
        checkScores(PlayerPrefs.GetInt("newScore"), PlayerPrefs.GetString("newName"));
        //delScores(); //uncomment to reset scores every playsession 

    }
    void saveScores()
    {
        for (int x = 0; x < highScoreInts.Length; x++)
        {
            PlayerPrefs.SetInt("highScoreInts" + x, highScoreInts[x]);
            PlayerPrefs.SetString("highScoreNames" + x, highScoreNames[x] );
        }
    }

    void delScores()
    {
        for (int x = 0; x < highScoreInts.Length; x++)
        {
            PlayerPrefs.SetInt("highScoreInts" + x, 0);
            PlayerPrefs.SetString("highScoreNames" + x, "");
        }
    }

    void drawScores()
    {
        for (int x = 0; x < highScoreInts.Length; x++)
        {
            highScores[x].text = highScoreInts[x].ToString().PadLeft(6) + highScoreNames[x].PadLeft(25).ToUpper();
        }
    }
    public void checkScores(int score, string name)
    {
        for (int x = 0; x < highScoreInts.Length; x++)
        {
            if(score > highScoreInts[x])
            {
                for (int y = highScoreInts.Length - 1; y>x; y--)
                {
                    highScoreInts[y] = highScoreInts[y - 1];
                    highScoreNames[y] = highScoreNames[y - 1];
                }
                highScoreInts[x] = score;
                highScoreNames[x] = name;
                drawScores();
                saveScores();
                break;
            }
        }
    }
     
}
