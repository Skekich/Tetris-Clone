using System;
using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;
using Random = UnityEngine.Random;

public class Spawner : MonoBehaviour
{
    [SerializeField] private GameObject[] tetraminos;

    private void Start()
    {
        SpawnNewRandomTatramino();
    }
    

    public void SpawnNewRandomTatramino()
    {
        Instantiate(tetraminos[Random.Range(0, tetraminos.Length)], transform.position, quaternion.identity);
    }
}