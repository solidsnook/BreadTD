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

    //breadMover bread;
    public List<GameObject> breadObjectList = new List<GameObject>();
    public GameObject[] bSprites;
    public Transform spawnPoint;
    private NodesScript ns;

    public Transform target;


    public void SpawnBread()
    {
        foreach (GameObject preSprites in bSprites)
        {
            GameObject EBread = Instantiate(preSprites, spawnPoint.position, Quaternion.identity);
            breadObjectList.Add(EBread);
            bSprites = breadObjectList.ToArray();
        }
    }
    
    
    /*public void BreadShallMove()
    {
        foreach (GameObject sprites in bSprites)
        {
            foreach (GameObject mNodes in ns.moverNodes)
            {
                for (int i = 0; i < bSprites.Length; i++) 
                {
                    Vector3 distance = sprites.transform.position - mNodes.transform.position;
                    var step = speed * Time.deltaTime;
                    Vector3.MoveTowards(transform.position, mNodes.transform.position, step);
                }

            }
        }
    } */

    // Start is called before the first frame update
    void Start()
    {
        SpawnBread();
    }

    // Update is called once per frame
    void Update()
    {
       //BreadShallMove();
    }
}


