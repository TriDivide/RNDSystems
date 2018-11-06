using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {


    World world;

	// Use this for initialization
	void Start () {
        world = new World(10, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
