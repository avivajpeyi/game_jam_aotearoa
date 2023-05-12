using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileGenerator : MonoBehaviour
{
    private int count=0; 
    
     
    
    [SerializeField] public float yPos = 0.0f;
    [SerializeField] private int initialTiles = 15;
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint = Vector3.zero;

    // set this to true to test the tile generator
    public bool testMode; // public so we can change it in script 1 location
    
    
    /// <summary>
    /// Spawn new tile at the next spawn point.
    /// </summary>
    /// <param name="spawnCrap"></param>
    public void SpawnTile (bool spawnCrap)
    {
        count++;
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        FloorTile tile = temp.GetComponent<FloorTile>();
        tile.Initialise(spawner:this, spawnCrap:spawnCrap);
        // nextSpawnPoint = temp.transform.GetChild(1).transform.position;
        
        // Update the next spawn point
        nextSpawnPoint = tile.GetNextSpawnPoint(); 
    }

    private void Start () {
        for (int i = 0; i < initialTiles; i++) {
            if (i < 3) { // dont spawn crap on the first 3 tiles
                SpawnTile(false);
            } else {
                SpawnTile(true);
            }
        }
    }
    
    private void Update () {
        if (testMode && Input.GetKeyDown(KeyCode.O)) {
            SpawnTile(true);
        }
    }
}
