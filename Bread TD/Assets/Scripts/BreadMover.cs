using System.Collections;
using System.Collections.Generic;
using NUnit.Framework.Interfaces;
using TreeEditor;
using Unity.VisualScripting;
using UnityEngine;

public class BreadMover : MonoBehaviour
{
    public float health;

    [SerializeField] private int nextNode = 0; // viewable in the prefabs to see what node it is attempting to reach.

    public NodesScript ns;

    void bHealthTDamage(int dmgAmount) //die code that works with the script from Reece with the towers.
    {
        health -= dmgAmount;
        if (health <= 0)
        {
            die();
        }
    }
    void die()
    {
        Destroy(this.gameObject);
    }
    public float moveSpeed;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // this gets the node array NS. The first step is the check for if the array is not null so we don't have the bread move to nothing or cause a crash when there are no nodes in the array.
        // the moveSpeed is defined by the public int which is editable when you attach this script to the prefabs.
        if (ns != null)
        {
            float stepBread = moveSpeed * Time.deltaTime;
            if (nextNode == ns.moverNodes.Length) // So far it does nothing it if reaches the end of list, This can be worked on to add GameManager stuff to end the level or add game over mechanic.
            {
                //end of list
            }
            else // this moves the bread to the node and increases the nextNode once it reaches it.
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


