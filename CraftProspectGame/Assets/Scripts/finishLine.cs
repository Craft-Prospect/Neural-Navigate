using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
 * Handles the finish line and initiates game over on move
 */

public class finishLine : MonoBehaviour {

    //Load game_over on player contact with finish line
    public void OnTriggerEnter2D(Collider2D collision)
    {
        SceneManager.LoadScene("Game_over");
    }
}
