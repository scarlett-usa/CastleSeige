using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScriptableTile : ScriptableObject
{
   [SerializeField] public TileMovement Y_Move {get; set;}
   [SerializeField] public TileMovement X_Move {get; set;}
   [SerializeField] public TileType Tile_Type {get; set;}
   [SerializeField] public TileType[] WeakAgainst {get; set;}
   [SerializeField] public TileType[] StrongAgainst {get; set;}
}

public enum TileMovement{
    one,
    two,
    three
}

public enum TileType{
    Rock,
    Paper,
    Scissor
}