using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {

    float lerpMovement;
    Vector3 startPosition, endPosition;
    float spawnTime;
    float waterHeightPercent;
    float perc;
    float lerpTime;
    float currentLerpTime;

    private GameObject water;


    // Start is called on init
    private void Start() {
        water = GameObject.Find("DummyWater");        
    }


    // Update is called once per frame
    void Update () {
        if (perc == 1) {
            lerpTime = 1;
            currentLerpTime = 0;
        }

        // get the position of the player before movement
        startPosition = gameObject.transform.position;

        // setting the position of the player after movement
        endPosition = new Vector3(transform.position.x, transform.position.y, transform.position.z - 1);
        

        // Use a lerp to move the player to the end position calculated above
        currentLerpTime += Time.deltaTime * 5;
        perc = currentLerpTime / lerpTime;
        if (waterHeightPercent == 1) {
            waterHeightPercent = 0.2F;
            Instantiate(water, gameObject.transform.position, gameObject.transform.rotation);
            gameObject.transform.position = Vector3.Lerp(startPosition, endPosition, perc);
            if (perc > 0.8) {
                perc = 1;
            }
        }
        else {
            gameObject.transform.localScale += new Vector3(0, waterHeightPercent, 0);
            waterHeightPercent += waterHeightPercent + 0.2F;
            if (waterHeightPercent <= 0.9F) {
                waterHeightPercent = 1;
            }
        }
    }
}
