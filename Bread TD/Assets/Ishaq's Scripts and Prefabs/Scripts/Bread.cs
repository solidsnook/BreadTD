using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;
using UnityEngine;

public class Bread : MonoBehaviour
{
    public float health;
    public float speed;

    public GameObject GameManager;

    //breadMover bread;
    public List<GameObject> breadObjectList = new List<GameObject>();
    public GameObject[] bSprites;
    public Transform spawnPoint;
    private NodesScript ns;

    public Transform target;

    public float spawnDelay = 5.0f;

    public int currentIndex = 0;

    public void SpawnBread()
    {
        StartCoroutine(SpawnBreadWithDelay());

        IEnumerator SpawnBreadWithDelay()
        {
            GameObject EBread;
            while (currentIndex < bSprites.Length)
            //foreach (GameObject preSprites in bSprites)
            {
                Debug.Log("I have spawned");
                EBread = Instantiate(bSprites[currentIndex], spawnPoint.position, Quaternion.identity);
                EBread.AddComponent<BreadMover>();
                EBread.GetComponent<BreadMover>().ns = gameObject.GetComponent<NodesScript>();
                EBread.GetComponent<BreadMover>().moveSpeed = 1;
                breadObjectList.Add(EBread);
                //bSprites = breadObjectList.ToArray();

                currentIndex++;
                yield return new WaitForSeconds(spawnDelay);

            }
            Debug.Log("I am now waiting for seconds: " + spawnDelay + " seconds has elapsed");
            Debug.Log("I am now at index: " + currentIndex);
        }

    }

    public void killBread()
    {
        if (health <= 0)
        {
            //implement death code for spawner children. 
        }
        return;
    }
    

    // Start is called before the first frame update
    void Start()
    {
        SpawnBread();
    }

    // Update is called once per frame
    void Update()
    {
        //killBread();
    }
}


