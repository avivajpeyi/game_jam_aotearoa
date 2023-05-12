using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class TileGenerator : MonoBehaviour
{
    
    
    [SerializeField] private bool testMode; // set this to true to test the tile generator
    [SerializeField] public float yPos = 0.0f;
    [SerializeField] private int initialTiles = 15;
    [SerializeField] GameObject groundTile;
    Vector3 nextSpawnPoint = Vector3.zero;

    /// <summary>
    /// Spawn new tile at the next spawn point.
    /// </summary>
    /// <param name="spawnCrap"></param>
    ///  s
    public void SpawnTile (bool spawnCrap)
    {
        GameObject temp = Instantiate(groundTile, nextSpawnPoint, Quaternion.identity);
        nextSpawnPoint = temp.transform.GetChild(1).transform.position;

        if (spawnCrap) {
            temp.GetComponent<FloorTile>().SpawnObstacle();
            temp.GetComponent<FloorTile>().SpawnPickups();
        }
    }

    private void Start () {
        for (int i = 0; i < initialTiles; i++) {
            if (i < 3) { // dont spawn crap on the first 3 tiles
                SpawnTile(false);
            } else {
                SpawnTile(true);
            }
        }
        
        if (testMode) {
            if (Input.GetKeyDown(KeyCode.Space)) {
                SpawnTile(true);
            }
        }
    }
}
