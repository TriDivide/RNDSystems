using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour {

    private GameObject SelectedGridCell;

    //private List<GameObject> SelectedUnits;
    private GameObject SelectedUnit;


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

    public void SelectUnit(GameObject unit) {
        Debug.Log("Select unit");
        if (SelectedUnit != null) {
            SelectedUnit.gameObject.GetComponent<MeshRenderer>().material.color = Color.grey;
        }

        SelectedUnit = unit;

        SelectedUnit.gameObject.GetComponent<MeshRenderer>().material.color = Color.blue;

    }

    public bool GetIfSelected(GameObject target) {
        return (target == SelectedUnit);
    }


    public GameObject GetGridCell() {
        return SelectedGridCell ?? null;
    }

    public void SelectGridCell(GameObject gridCell) {
        if (SelectedGridCell != null) {
            SelectedGridCell.gameObject.GetComponent<MeshRenderer>().material.color = Color.white;
        }
        SelectedGridCell = gridCell;

        SelectedGridCell.gameObject.GetComponent<MeshRenderer>().material.color = Color.green;
    }

}
