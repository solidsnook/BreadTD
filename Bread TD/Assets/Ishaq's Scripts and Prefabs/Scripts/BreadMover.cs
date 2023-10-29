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
        if (ns != null)
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
}


