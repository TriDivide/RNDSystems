using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GridGenerator : MonoBehaviour {


    public int GridHeight, GridWidth;
    
    public GameObject GridSquare;

	// Use this for initialization
	void Start () {
        GenerateGrid();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void GenerateGrid() {
        float currentX = 0f;
        float currentZ = 0f;

        for (int row = 0; row < GridHeight; row++) {
            GameObject gridCell = null;
            for (int column = 0; column < GridWidth; column++) {
                gridCell = Instantiate(GridSquare);
                gridCell.transform.position = new Vector3(currentX, 0, currentZ);
                currentX += gridCell.transform.localScale.x;
            }
            currentX = 0f;
            currentZ += gridCell.transform.localScale.z;
        }
    }
}