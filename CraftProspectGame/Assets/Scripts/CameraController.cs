using UnityEngine;

/*
 * Moves camera together with the player character
 */

public class CameraController : MonoBehaviour {

    public GameObject targetPlayer;
    //public Transform targetPlayer = null;
    public float smoothTime = 0.3f;

    private Vector3 camVel = Vector3.zero;


    private void Update(){
        if (targetPlayer != null)
            transform.position = Vector3.SmoothDamp(transform.position,
              new Vector3((targetPlayer.transform.position.x + 7), transform.position.y, transform.position.z), ref camVel, smoothTime);
        /* Drags camera smoothly behind player:
         *'targetPlayer.transform.position.x + 'y' - y effects horizontal skewness of camera'
         * smoothtime effects how quickly camera is adjusted to correct location
         */
    }
}
