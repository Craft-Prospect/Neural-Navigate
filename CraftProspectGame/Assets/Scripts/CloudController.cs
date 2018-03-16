using System;
using UnityEngine;
using UnityEngine.PostProcessing;

/* Script adds effects when a player is in a cloud:
 * A light static is added to alert player they are in a cloud
 * If the player activates their "energy" while in the cloud the effect worsens
 * Effect returns to normal over time when player leaves cloud
 */

public class CloudController : MonoBehaviour {

    public GameObject mainCamera;
    private PostProcessingBehaviour ppb;
    private PostProcessingProfile m_Profile;
    private float smoothMulti;
    public bool energyCheck = Energy.energyEnabled;
    public bool incloud = false;

    private void Update(){
        try{
            var vignette = m_Profile.vignette.settings;
            //check whether the player is in the cloud or not
            if(ppb.enabled){
                if(!incloud){
                    smoothMulti = 0.98f;
                }
                else{
                    smoothMulti = 1.08f;
                }
            }
            // if effect is activated, make sure it cannot scale too high
            if(ppb.enabled){
                if(vignette.smoothness >= 3f){
                    vignette.smoothness = 3f;

                }
                vignette.smoothness = vignette.smoothness * smoothMulti;
                //and make sure it cannot become too low
                if (vignette.smoothness <= 0.04f){
                    ppb.enabled = false;
                    vignette.smoothness = 0.05f;
                }
            }
            m_Profile.vignette.settings = vignette;
        }
        catch (NullReferenceException e){
        }
    }


    void OnTriggerEnter2D(Collider2D other){
        incloud = true;
        ppb = mainCamera.GetComponent<PostProcessingBehaviour>();
        ppb.enabled = true;
        m_Profile = Instantiate(ppb.profile);
        ppb.profile = m_Profile;
        smoothMulti = 1.02f;
    }

    void OnTriggerExit2D(Collider2D other){
        incloud = false;
        smoothMulti = 0.98f;
    }
}
