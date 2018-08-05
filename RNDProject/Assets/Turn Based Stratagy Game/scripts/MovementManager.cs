using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {

    private GameObject SelectedGridCell;


    public static MovementManager Instance;


    void GetInstance() {
        if (Instance != null) {
            Destroy(gameObject);
        }
        else {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
    }
	// Use this for initialization
	void Start () {
        GetInstance();
	}
	

    public void SelectGridCell(GameObject gridCell) {
        if (SelectedGridCell != null) {
            SelectedGridCell.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        SelectedGridCell = gridCell;

        SelectedGridCell.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }

}
