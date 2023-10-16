using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using Unity.VisualScripting;
using UnityEngine;

public class BreadMover : MonoBehaviour
{

   // private int nextNode = 0;

    private Bread bs;

    private NodesScript ns;

    public int FindIndexOfGameObject(GameObject targetObj)
    {
        foreach (GameObject mNodes in ns.moverNodes)
        for (int i = 0; i < ns.moverNodes.Length; i++)
        {
            if (ns.moverNodes[i] == targetObj)
            return i;
        }

        return -1;
    }

[SerializeField] private float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (GameObject mNoders in ns.moverNodes)
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
    }
}
