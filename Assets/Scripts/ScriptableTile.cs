using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine;



[CreateAssetMenu(fileName = "Tile", menuName = "ScriptableObjects/Tile", order = 1)]
public class ScriptableTile : ScriptableObject
{
   public TileMovement Y_Move;
   public TileMovement X_Move;
   public TileType Tile_Type;
   public TileType[] WeakAgainst;
   public TileType[] StrongAgainst;
}

[Serializable]
public enum TileMovement{
    one,
    two,
    three
}

[Serializable]
public enum TileType{
    Rock,
    Paper,
    Scissor
}