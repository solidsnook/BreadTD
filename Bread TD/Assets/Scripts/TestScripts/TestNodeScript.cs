using NUnit.Framework.Interfaces;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TestNodeScript : MonoBehaviour
{
    public GameObject[] nodeList;
    public GameObject[] breadList;
    public GameObject randomBread;
    public GameObject currentBread;
    public GameObject spawner;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < breadList.Length; i++)
        {
            currentBread = Instantiate(randomBread, this.transform.position, Quaternion.identity);
            TestBreadScript bread = breadList[i].AddComponent<TestBreadScript>();
            bread.currentBread = breadList[i];
        }

        for (int i2 = 0; i2 < nodeList.Length; i2++) 
        {
            Vector3 direction = currentBread.transform.position - transform.position;
            direction.Normalize();

            // Move Shot to Bread
            //transform.Translate(direction * shotSpeed * Time.deltaTime);
        }
    }
}
