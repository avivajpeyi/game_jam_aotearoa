using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// FloorTile contains all the data and functionality for a FloorTile 
/// These are only instantiated by the TileGenerator.
/// 
/// Must have a child objects:
///     "NextSpawnPoint" -- transform for the next tile to spawn
///     "ObstacleSpwnPtLeft" -- transform for the left obstacle spawn point
///     "ObstacleSpwnPtMid" -- transform for the middle obstacle spawn point
///     "ObstacleSpwnPtRight" -- transform for the right obstacle spawn point
///
/// Must have a collider to detect when the player has left the tile
/// The collider also defines the area that pickups and obstacles can spawn.
///
/// The layer of the collider must be set to "Floor" so that the player
/// can walk on it.
/// </summary>
[RequireComponent(typeof(Collider))]
public class FloorTile : MonoBehaviour
{
    Collider _collider;
    TileGenerator _spawner;
    private Transform _nextSpawnPoint;



    public void Initialise(TileGenerator spawner, bool spawnCrap = true,
        int numPickups = 1)
    {
        _spawner = spawner;
        _collider = GetComponent<Collider>();
        _nextSpawnPoint = transform.Find("NextSpawnPoint");
        
        

    }


    public Vector3 GetNextSpawnPoint()
    {
        return _nextSpawnPoint.position;
    }

    private void OnTriggerExit(Collider other)
    {
        _spawner.SpawnTile(true);
        Destroy(gameObject, 10);
    }

    Vector3 GetRandomPointInCollider()
    {
        Vector3 point = new Vector3(
            Random.Range(_collider.bounds.min.x, _collider.bounds.max.x),
            Random.Range(_collider.bounds.min.y, _collider.bounds.max.y),
            Random.Range(_collider.bounds.min.z, _collider.bounds.max.z)
        );

        // add 1 to the y position so the pickup is above the ground
        point.y = _spawner.yPos + 1.0f; 
        return point;
    }
}