using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class RandomlyEnable : MonoBehaviour
{
    [SerializeField] float probability = 0.1f;
    MeshRenderer meshRenderer;
    
    // Start is called before the first frame update
    void Start()
    {
        if(Random.Range(0f, 1f) > probability)
        {
            Destroy(gameObject);
        }
    }


    
}
