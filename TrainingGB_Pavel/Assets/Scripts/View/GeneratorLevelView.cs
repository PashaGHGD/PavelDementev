using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class GeneratorLevelView : MonoBehaviour {
    public Tilemap Tilemap;
    public Tile Tile;
    public int MapHeight;
    public int MapWidth;

    [Range(0, 100)] public int FillPersent;
    [Range(0, 100)] public int SmoothPercent;

    public bool Borders;
    void Start() {

    }


    void Update() {

    }
}
