using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveText : MonoBehaviour
{
    float MoveSpeed;
    float SetSpeed;

    GameObject[] Targets;

    int nextTarget = 0;

    // Update is called once per frame
    void Update()
    {
        //text takes nodes and travels towards nodes starting fast and then slowing down when reaching first node and then speeding up for second node

        if (Targets == null) return;

        //if targets finished then destroy this object
        if(nextTarget >= Targets.Length)
        {
            Destroy(this.gameObject);
            return;
        }

        //movespeed is calculated based on distance from the starting point to next target and the setspeed of the text
        float distance = Vector3.Distance(transform.localPosition, Targets[nextTarget].transform.localPosition);
        MoveSpeed = ((0.0001f * distance * distance) + 5f) * SetSpeed;

        //move this text to the target
        if (nextTarget == 1)
        {
            float lastDistance = Vector3.Distance(Targets[nextTarget - 1].transform.localPosition, Targets[nextTarget].transform.localPosition);
            MoveSpeed = (0.0001f * (distance - lastDistance) * (distance - lastDistance)) + 5f;
        }
        transform.position = Vector3.MoveTowards(transform.position, Targets[nextTarget].transform.position, MoveSpeed * Time.deltaTime);

        //when target reached go to next target
        if (Vector3.Distance(transform.localPosition, Targets[nextTarget].transform.localPosition) <= 1)
        {
            Debug.Log("target reached");
            nextTarget++;
        }
    }

    public void Initialize(float speed, GameObject[] Nodes)
    { 
        SetSpeed = speed;
        Targets = Nodes;
    }
}
