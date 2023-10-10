using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Bread : MonoBehaviour
{
    public float health;
    public float speed;

    public GameObject[] bSprites;
    public Transform spawnPoint;

    public void SpawnBread()
    {
        foreach (GameObject preSprites in bSprites)
        {
            GameObject EBread = Instantiate(preSprites, spawnPoint.position, Quaternion.identity);
        }
    }
    // Start is called before the first frame update
    void Start()
    {
        SpawnBread();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
