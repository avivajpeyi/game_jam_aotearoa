using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RandomMesh : MonoBehaviour
{
    [SerializeField] List<Mesh> meshes = new List<Mesh>();

    void Start()
    {
        Mesh myMesh = meshes[Random.Range(0, meshes.Count)];
        GetComponent<MeshFilter>().mesh = myMesh;
    }
}
