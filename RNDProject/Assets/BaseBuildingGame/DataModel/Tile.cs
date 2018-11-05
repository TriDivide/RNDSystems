using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tile {

    public enum TileType {
        Dirt,
        Stone,
        Paved,
        RunningWater,
        StillWater,
        Sand,
        ShallowWater,
        Grass,
        Foundations
    }

    TileType type = TileType.Dirt;

    
}