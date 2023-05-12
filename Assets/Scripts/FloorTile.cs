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
    private GameObject _pickupPrefab;
    private GameObject _obstaclePrefab;
    private Transform _nextSpawnPoint;
    private List<Transform> _obstacleSpawnPoints = new List<Transform>();
    private int numPickups = 1;


    public void Initialise(TileGenerator spawner, bool spawnCrap = true,
        int numPickups = 1)
    {
        _spawner = spawner;
        _collider = GetComponent<Collider>();
        _pickupPrefab = Resources.Load<GameObject>("Pickup");
        _obstaclePrefab = Resources.Load<GameObject>("Obstacle");
        _nextSpawnPoint = transform.Find("NextSpawnPoint");
        _obstacleSpawnPoints.Add(transform.Find("ObstacleSpwnPtLeft"));
        _obstacleSpawnPoints.Add(transform.Find("ObstacleSpwnPtMid"));
        _obstacleSpawnPoints.Add(transform.Find("ObstacleSpwnPtRight"));
        this.numPickups = numPickups;
        if (spawnCrap)
        {
            SpawnObstacle();
            SpawnPickups();
        }

        foreach (Transform spawnPoint in _obstacleSpawnPoints)
        {
            Destroy(spawnPoint.gameObject);
        }
    }


    public Vector3 GetNextSpawnPoint()
    {
        return _nextSpawnPoint.position;
    }

    private void OnTriggerExit(Collider other)
    {
        _spawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        // 0 to N-1 where N is the number of spawn points (so at least 1 exit)
        int numObstacles = Random.Range(0, _obstacleSpawnPoints.Count - 1);
        for (int i = 0; i < numObstacles; i++)
        {
            int obstacleSpawnIndex = Random.Range(0, _obstacleSpawnPoints.Count);
            Transform spawnPoint = _obstacleSpawnPoints[obstacleSpawnIndex];
            Instantiate(_obstaclePrefab, spawnPoint.position, Quaternion.identity,
                transform);
            _obstacleSpawnPoints.RemoveAt(obstacleSpawnIndex);
        }
    }


    public void SpawnPickups()
    {
        for (int i = 0; i < numPickups; i++)
        {
            GameObject temp = Instantiate(_pickupPrefab, transform);
            temp.transform.position = GetRandomPointInCollider();
        }
    }

    Vector3 GetRandomPointInCollider()
    {
        Vector3 point = new Vector3(
            Random.Range(_collider.bounds.min.x, _collider.bounds.max.x),
            Random.Range(_collider.bounds.min.y, _collider.bounds.max.y),
            Random.Range(_collider.bounds.min.z, _collider.bounds.max.z)
        );

        point.y =
            _spawner.yPos +
            1.0f; // add 1 to the y position so the pickup is above the ground
        return point;
    }
}