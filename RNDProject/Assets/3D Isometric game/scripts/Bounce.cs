using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce : MonoBehaviour {

    float lerpTime;
    float currentLerpTime;
    float perc = 1;

    Vector3 startPosition, endPosition;


	// Update is called once per frame
	void Update () {
		if (Input.GetButtonDown("up") || Input.GetButtonDown("down") || Input.GetButtonDown("left") || Input.GetButtonDown("right")) {
            if (perc == 1) {
                lerpTime = 1;
                currentLerpTime = 0;
            }
        }
        startPosition = gameObject.transform.position;
        
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

        currentLerpTime += Time.deltaTime + 5.5F;
        perc = currentLerpTime / lerpTime;
        gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, perc);
    }
}
