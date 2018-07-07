using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

    float lerpTime;
    float currentLerpTime;
    float perc = 1;

    Vector3 startPosition, endPosition;


    bool firstInput;

    public bool justJump;

	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("up") || Input.GetButtonDown("down") || Input.GetButtonDown("left") || Input.GetButtonDown("right")) {
            if (perc == 1) {
                lerpTime = 1;
                currentLerpTime = 0;
                firstInput = true;
                justJump = true;
            }
        }
        // get the position of the player before movement
        startPosition = gameObject.transform.position;
        
        // setting the position of the player after movement
        if (Input.GetButtonDown("right") && gameObject.transform.position == endPosition) {
            endPosition = new Vector3(transform.position.x + 1, transform.position.y, transform.position.z);
        }
        if (Input.GetButtonDown("left") && gameObject.transform.position == endPosition) {
            endPosition = new Vector3(transform.position.x - 1, transform.position.y, transform.position.z);
        }
        if (Input.GetButtonDown("up") && gameObject.transform.position == endPosition) {
            endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
        }
        if (Input.GetButtonDown("down") && gameObject.transform.position == endPosition) {
            endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        }

        // Use a lerp to move the player to the end position calculated above
        if (firstInput) {
            currentLerpTime += Time.deltaTime;
            perc = currentLerpTime / lerpTime;
            gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, perc);
            if (perc > 0.8) {
                perc = 1;
            }
            if (Mathf.Round(perc) == 1) {
                justJump = false;
            }
        }
    }
}
