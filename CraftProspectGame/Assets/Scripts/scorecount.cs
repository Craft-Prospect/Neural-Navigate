using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* These values are used to send to the customer. The 'yes'/'no' values 
 * are answers to the game survey question, 'Did the game help understand Neural Networks
 */
public class scorecount : MonoBehaviour {

	int yes = 0;
	int no = 0;

	public void update_Yes(){
		yes += 1; 
	}

	public void update_No(){
		no += 1; 
	}
}
