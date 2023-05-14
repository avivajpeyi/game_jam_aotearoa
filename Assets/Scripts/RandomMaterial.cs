using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomMaterial : MonoBehaviour
{
    [SerializeField] Material[] MyMaterials;
    
    private  float speed = 0.01f;
    
    // Randomly move a bit up and down
    void Update()
    {
        transform.position += new Vector3(0, Mathf.Sin(Time.time * 2) * speed, 0);
    }

    private void Start()
    {
        Material m = MyMaterials[Random.Range(0, MyMaterials.Length)];
        GetComponent<MeshRenderer>().material = m;
        // Random inital y position
        transform.position += new Vector3(0, Random.Range(-2f, 2f), 0);
        speed = Random.Range(-0.01f, 0.01f);
    }
}