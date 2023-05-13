using System.Collections;
using System.Collections.Generic;
using UnityEngine;



[CreateAssetMenu(fileName = "SOEvents", menuName = "SOs/TilesList")]
public class TilesList : ScriptableObject
{
    
    [System.Serializable]
    public class Tile
    {
        public GameObject tile;
        public float probability;
    }
    
    public List<Tile> tiles = new List<Tile>();


    public GameObject GetTilePrefab()
    {
        
        // Select a random tile from the list
        Tile t  = tiles[Random.Range(0, tiles.Count)];
        if (Random.value > t.probability)
        {
            return GetTilePrefab();
        }
        else
        {
            return t.tile;
        }
    }
    
}
