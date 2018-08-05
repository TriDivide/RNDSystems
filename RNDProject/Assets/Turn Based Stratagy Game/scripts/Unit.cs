using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit : MonoBehaviour {

    private GameObject SelectedCell;


    public float MovementSpeed;

    // Use this for initialization
    void Start() {

    }

    // Update is called once per frame
    void Update() {
        float step = MovementSpeed * Time.deltaTime;
        SetSelectedCell();

        Debug.Log(MovementManager.Instance.GetIfSelected(gameObject));

        if (SelectedCell != null && MovementManager.Instance.GetIfSelected(gameObject)) {
            var cellPosition = SelectedCell.transform.position;
            cellPosition = new Vector3(cellPosition.x, 1.25f, cellPosition.z);
            transform.position = Vector3.MoveTowards(transform.position, cellPosition, step);
            if (cellPosition == gameObject.transform.position) {
                MovementManager.Instance.SelectGridCell(null);
            }
        }

    }

    void OnMouseOver() {
        Debug.Log("Select a unit");
        if (Input.GetMouseButtonDown(1)) {
            MovementManager.Instance.SelectUnit(gameObject);
        }
    }

    void SetSelectedCell() {
        SelectedCell = MovementManager.Instance.GetGridCell();
    }

}
