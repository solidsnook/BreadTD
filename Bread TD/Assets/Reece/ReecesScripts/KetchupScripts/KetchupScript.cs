using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
using UnityEditor.Animations;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class KetchupScript : MonoBehaviour
{
    // Declaring Variables
    public float damage = 10f;          // How much damage the shot does
    public float speed = 3f;            // How fast the shot can move
    public float fireRate = 1f;         // How fast the tower can shoot
    public float attackRange = 20f;     // How far can the enemy be for the tower to shoot
    public float cost = 10f;            // How much the tower costs to place down
    public float sellValue;             // How much you can sell the tower for
    public int towerLevel;              // What tower level the tower is currently on
    public GameObject KetchupShot;      // Prefab for the Ketchup Shot
    public Animator animator;           // This is the animator for the tower
    
    private GameObject enemy;
    private float time = 0f;

    // Update is called once per frame
    void Update()
    {
        time = time + 1f * Time.deltaTime;

        sellValue = cost / 2 * towerLevel; 

        // Updates the attackRange variable to the radius of the collider so it can be easily changed
        GetComponent<CircleCollider2D>().radius = attackRange;

        if (enemy != null)
        {
            // Delay until next shot
            if (time >= fireRate)
            {
                Shoot();
                time = 0f;
            }
        }
    }

    void Shoot()
    {
        // Position of Tower
        float x = this.transform.position.x;
        float y = this.transform.position.y;

        // Play Shooting Animation
        animator.SetTrigger("IsShooting?");
       
        // Spawn Ketchup Shot
        GameObject currentShot = Instantiate(KetchupShot, new Vector2(x, y + 1.4f), Quaternion.identity);
        
        // Adding new script to shot
        KetchupShotScript shot = currentShot.AddComponent<KetchupShotScript>();

        // Save speed to new shot script
        shot.shotSpeed = speed;
        shot.ketchupDamage = damage;
        shot.target = enemy;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // Finds the enemy thats in range and with the tag "Enemy"
        if (collision.CompareTag("breadBasic") || collision.CompareTag("breadSpeedy") || collision.CompareTag("breadICannotRemember"))
        {
            enemy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Reset the enemy reference when it exits the trigger.
        if (collision.CompareTag("breadBasic") || collision.CompareTag("breadSpeedy") || collision.CompareTag("breadICannotRemember"))
        {
            enemy = null;
        }
    }
}
