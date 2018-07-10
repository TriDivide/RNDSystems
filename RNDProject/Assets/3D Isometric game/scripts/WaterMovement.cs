using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterMovement : MonoBehaviour {

    float waterHeightPercent;
    float height = 0.2F;

    private GameObject water;


    // Start is called on init
    private void Start() {
        water = GameObject.Find("DummyWater");
        gameObject.transform.localScale = new Vector3(0, 0.2F, 0);
        StartCoroutine("updateWater");

    }


    // Update is called once per frame
    void Update () {
    }

    IEnumerator updateWater() {
        for (; ; ) {

            print("current height percent: " + waterHeightPercent);
            if (waterHeightPercent == 1) {
                print("move the water");
                waterHeightPercent = height;

                Instantiate(water, gameObject.transform.position, gameObject.transform.rotation);
                
                gameObject.transform.localScale = new Vector3(0, height, 0);
                gameObject.transform.position = new Vector3(gameObject.transform.position.x, gameObject.transform.position.y, gameObject.transform.position.z -4);

            } else {
                print("set the height of the water");
                gameObject.transform.localScale += new Vector3(0,  height, 0);
                waterHeightPercent += height;
                if (waterHeightPercent >= 0.9F) {
                    waterHeightPercent = 1;
                }
            }

            yield return new WaitForSeconds(1);
        }
    }
}
