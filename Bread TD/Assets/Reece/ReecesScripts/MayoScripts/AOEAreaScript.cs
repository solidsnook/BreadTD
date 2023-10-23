using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAreaScript : MonoBehaviour
{
    public float mayoDamage;
    public float aoe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        GetComponent<CircleCollider2D>().radius = aoe;
    }
}
