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

    //Josh Code (Rference used for player health system - when bread reaches last node it triggers a function to take damage)
    private PlayerHealthSystem PHS;
    public GameObject HealthSystem;
    //Josh Code End
    public void SpawnBreadOfType(GameObject bread)
    {
        GameObject EBread;
        Debug.Log("I have spawned");
        EBread = Instantiate(bread, spawnPoint.position, Quaternion.identity);
        EBread.GetComponent<BreadMover>().ns = gameObject.GetComponent<NodesScript>();
        //Josh Code
        EBread.GetComponent<BreadMover>().PHS = HealthSystem.GetComponent<PlayerHealthSystem>();
        //Josh Code End
        GameManager.GetComponent<GameManager>().AliveBreads.Add(EBread); //adds bread to alive bread count
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


