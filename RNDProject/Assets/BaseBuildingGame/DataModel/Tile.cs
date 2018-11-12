using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class Tile {

    Action<Tile> tileTypeChangedObserver;

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

            if (tileTypeChangedObserver != null) {
                tileTypeChangedObserver(this);
            }
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

    public void RegisterTileTypeChangedObserver(Action<Tile> observer) {
        this.tileTypeChangedObserver += observer;
    }

    public void UnregisterTileTypeChangedObserver(Action<Tile> observer) {
        this.tileTypeChangedObserver -= observer;
    }
}