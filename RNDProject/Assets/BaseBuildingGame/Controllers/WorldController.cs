using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorldController : MonoBehaviour {

    public Sprite tileSprite;

    World world;

    float randomizer = 2f;
	// Use this for initialization
	void Start () {
        world = new World(10, 10);
        GenerateTiles();

        world.RandomizeTiles();
	}
	
	// Update is called once per frame
	void Update () {

        randomizer -= Time.deltaTime;

        if (randomizer < 0) {
            world.RandomizeTiles();
            randomizer = 2f;
        }
	}

    void GenerateTiles() {
        //Create a game object for each tile, so that they show visually
        for (int x = 0; x < world.Width; x++) {
            for (int y = 0; y < world.Height; y++) {

                GameObject tileGameObject = new GameObject();
                tileGameObject.name = "Tile_" + x + "," + y;


                SpriteRenderer tileSprite = tileGameObject.AddComponent<SpriteRenderer>();

                Tile tileData = world.getTileAt(x, y);
                tileGameObject.transform.position = new Vector3(tileData.PosX, tileData.PosY, 0);


            }
        }
    }

//ToDo: Make a switch statment to fufill all types in enum.
    void onTileTyeChanged(Tile tileData, GameObject tileGameObject) {
        if (tileData.Type == Tile.TileType.Dirt) {
            tileGameObject.GetComponent<SpriteRenderer>().sprite = tileSprite;
        }
        else {
            tileGameObject.GetComponent<SpriteRenderer>().sprite = null;
        }
    }
}
