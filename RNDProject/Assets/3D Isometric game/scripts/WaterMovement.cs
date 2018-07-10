using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {

    float waterHeightPercent;
    float height = 0.2F;

    float time = 0;


    private GameObject water;


    // Start is called on init
    private void Start() {
        water = GameObject.Find("DummyWater");
        gameObject.transform.localScale = new Vector3(0, 0.2F, 0);

    }


    // Update is called once per frame
    void Update () {
      //  print("Time: "+time);
        //print("waterHeightPercent: " + waterHeightPercent);
        //print("height: " + height);
        if (time <= 0) {
            time = 1.5f;
            if (waterHeightPercent == 1) {
               // print("move the water");
                waterHeightPercent = height;

                Instantiate(water, gameObject.transform.position, gameObject.transform.rotation);

                gameObject.transform.localScale = new Vector3(0, height, 0);
                print("old local position: "+gameObject.transform.localPosition);
                Vector3 moveToPosition = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z - 4);
                gameObject.transform.Translate(moveToPosition);
                print("new local position: " +gameObject.transform.localPosition);
            } else {
                //print("set the height of the water");
                gameObject.transform.localScale = new Vector3(0, height, 0);
                waterHeightPercent += height;
                if (waterHeightPercent >= 0.9F) {
                    waterHeightPercent = 1;
                }
            }
        }   
        time -= Time.deltaTime;
    }
}
