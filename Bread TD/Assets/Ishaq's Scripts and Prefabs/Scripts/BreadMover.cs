using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

public class BreadMover : MonoBehaviour
{

   [SerializeField] private int nextNode = 0;

    //public Bread bs;
    
    public NodesScript ns;

    /*public int FindIndexOfGameObject(GameObject targetObj)
    {
        foreach (GameObject mNodes in ns.moverNodes)
        for (int i = 0; i < ns.moverNodes.Length; i++)
        {
            if (ns.moverNodes[i] == targetObj)
            return i;
        }

        return -1;
    }*/

    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
      float stepBread = moveSpeed * Time.deltaTime;
        if (nextNode == ns.moverNodes.Length)
        {
            //end of list
        }
        else
        {
            Vector3 nextNodePos = ns.moverNodes[nextNode].transform.position; 
           transform.position = Vector3.MoveTowards(transform.position, nextNodePos, stepBread);
            if (Vector3.Distance(transform.position, nextNodePos) <= 0) 
            {
                nextNode++;
            }
        }
    }
}

 /* foreach (GameObject mNoders in ns.moverNodes)
        {
            int index = FindIndexOfGameObject(mNoders);
            if (index != -1)
            {
                Debug.Log("Index is Currently at :" + index);
                Transform idTransform = ns.moverNodes[index].transform;
                Vector3 idTransformPosition = idTransform.position;
            }
            else
            {
                Debug.Log("Index Not Found in array :");
            }

        }
    } */
