using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public GameObject GameManager;

    //breadMover bread;
    public List<GameObject> breadObjectList = new List<GameObject>();
    public GameObject[] bSprites;
    public Transform spawnPoint;
    private NodesScript ns;

    
    public Transform target;

    public float spawnDelay = 5.0f;

    public int currentIndex = 0;

    public void SpawnBreadOfType(GameObject bread)
    {
        // Take out of here.
        GameObject EBread;
        Debug.Log("I have spawned");
        EBread = Instantiate(bread, spawnPoint.position, Quaternion.identity);
        EBread.GetComponent<BreadMover>().ns = gameObject.GetComponent<NodesScript>();
    }

    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(SpawnBreadWithDelay());
       
        // create a thing that will spawn a certain prefab
    }

    IEnumerator SpawnBreadWithDelay()
    {
        for (int i = 0; i < bSprites.Length; i++)
        {
            SpawnBreadOfType(bSprites[i]);
            yield return new WaitForSeconds(spawnDelay);
        }
     
    }

    // Update is called once per frame
    void Update()
    {

    }
}


