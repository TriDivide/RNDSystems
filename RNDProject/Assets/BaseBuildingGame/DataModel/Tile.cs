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

    public TileType Type {
        get {
            return type;
        }

        set {
            type = value;

        }
    }

    LooseObject looseObject;
    InstalledObject installedObject;

    World world;

    int posX;
    public int PosX {
        get {
            return posX;
        }
    }

    int posY;
    public int PosY {
        get {
            return posY;
        }
    }
    public Tile(World world, int x, int y) {
        this.world = world;
        this.posX = x;
        this.posY = y;
    }
}