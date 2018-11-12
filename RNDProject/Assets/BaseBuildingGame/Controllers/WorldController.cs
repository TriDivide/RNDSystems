using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WorldController : MonoBehaviour {

    public Sprite grassSprite;
    public Sprite waterSprite;
    public Sprite pavedSprite;
    public Sprite dirtSprite;

    World world;

    float randomizer = 2f;
	// Use this for initialization
	void Start () {
        world = new World(100, 100);
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

                GameObject tileGameObject = new GameObject {
                    name = "Tile_" + x + "," + y
                };


                SpriteRenderer tileSprite = tileGameObject.AddComponent<SpriteRenderer>();

                Tile tileData = world.GetTileAt(x, y);
                tileGameObject.transform.position = new Vector3(tileData.PosX, tileData.PosY, 0);

                tileData.RegisterTileTypeChangedObserver((tile) => {
                    OnTileTyeChanged(tile, tileGameObject);
                });
            }
        }
    }

//ToDo: Make a switch statment to fufill all types in enum.
    void OnTileTyeChanged(Tile tileData, GameObject tileGameObject) {
        switch (tileData.Type) {
            case Tile.TileType.Dirt:
                tileGameObject.GetComponent<SpriteRenderer>().sprite = dirtSprite;
                break;
            case Tile.TileType.Grass:
                tileGameObject.GetComponent<SpriteRenderer>().sprite = grassSprite;
                break;
            case Tile.TileType.StillWater:
                tileGameObject.GetComponent<SpriteRenderer>().sprite = waterSprite;
                break;
            case Tile.TileType.Paved:
                tileGameObject.GetComponent<SpriteRenderer>().sprite = pavedSprite;
                break;
        }

    }
}
