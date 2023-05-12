using System.Collections;
using System.Collections.Generic;
using UnityEngine;


// ensure that a child object with the name "NextSpawnPoint" is present
public class FloorTile : MonoBehaviour
{
    Collider _collider;
    TileGenerator _spawner;
    private GameObject _pickupPrefab;
    private GameObject _obstaclePrefab;
    private Transform nextSpawnPoint;


    private void Start()
    {
        _collider = GetComponent<Collider>();
        _spawner = GameObject.FindObjectOfType<TileGenerator>();
        _pickupPrefab = Resources.Load<GameObject>("Pickup");
        _obstaclePrefab = Resources.Load<GameObject>("Obstacle");
        nextSpawnPoint = transform.Find("NextSpawnPoint");
        if (nextSpawnPoint == null)
        {
            Debug.LogError(
                "FloorTile: No child object with the name 'NextSpawnPoint' found!");
        }
    }

    public Vector3 GetNextSpawnPoint()
    {
        return nextSpawnPoint.position;
    }

    private void OnTriggerExit(Collider other)
    {
        _spawner.SpawnTile(true);
        Destroy(gameObject, 2);
    }

    public void SpawnObstacle()
    {
        // Choose a random point to spawn the obstacle
        int obstacleSpawnIndex = Random.Range(2, 5);
        Transform spawnPoint = transform.GetChild(obstacleSpawnIndex).transform;

        // Spawn the obstace at the position
        Instantiate(_obstaclePrefab, spawnPoint.position, Quaternion.identity, transform);
    }


    public void SpawnPickups(int pickupsToSpawn = 10)
    {
        for (int i = 0; i < pickupsToSpawn; i++)
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