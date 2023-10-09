using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;

public class KetchupScript : MonoBehaviour
{

    // Declaring Variables
    public float attackSpeed;
    public float health;
    public float cost;
    public float timeDelay;
    public float time;
    public GameObject bread;
    public GameObject KetchupShot;
    public GameObject selectedTile;

    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
        timeDelay = 3f;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + 1f * Time.deltaTime;

        if (bread != null)
        {
            if (time >= timeDelay)
            {
                Shoot();
                time = 0f;
            }
        }
        else
        {
            // Do Nothing
        }
    }

    private void FixedUpdate()
    {
        
    }

    void Shoot()
    {
        float x = this.transform.position.x;
        float y = this.transform.position.y;

        // Play Shooting Animation
        //this.gameObject.GetComponent<AnimatorController>;

        // Spawn Ketchup Shot
        Sprite currentShot = Sprite.Create(KetchupShot, new Vector2(x, y + 1.7f), Quaternion.identity);  //Instantiate(KetchupShot, new Vector2(x, y + 1.7f), Quaternion.identity);

        // Move Shot
        currentShot.transform.position = Vector2.MoveTowards(currentShot.transform.position, bread.transform.position, attackSpeed * Time.deltaTime);

        // Delay Until Next Shot
    }
}
