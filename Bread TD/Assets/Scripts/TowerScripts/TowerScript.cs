using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
//using UnityEditor.Animations;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class TowerScript : MonoBehaviour
{
    // Declaring Variables
    public float damage;            // How much damage the shot does
    public float speed;             // How fast the shot can move
    public float fireRate;          // How fast the tower can shoot
    public float attackRange;       // How far can the enemy be for the tower to shoot
    public int cost;              // How much the tower costs to place down
    public float sellValue;         // How much you can sell the tower for
    public int towerLevel;          // What tower level the tower is currently on
    public GameObject Shot;         // Prefab for the Ketchup Shot
    public float aoe;               // How big the area of damage is 
    public int poisonAmount;        // How many times the damage is taken
    private GameObject enemy;
    private float time = 0f;
    public Animator animator;

    //Audio Variable Declaration
    public AudioSource ShootSoundSource;
    public AudioClip ShootSoundEffect;

 

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
        ShootSoundSource.PlayOneShot(ShootSoundEffect);

        // Spawn Ketchup Shot
        GameObject currentShot = Instantiate(Shot, new Vector2(x, y + 1.2f), Quaternion.identity);

        // Adding new script to shot
        ShotScript shot = currentShot.GetComponent<ShotScript>();

        // Save speed to new shot script
        shot.shotSpeed = speed;
        shot.Damage = damage;
        shot.target = enemy;
        shot.aoeRange = aoe;
        shot.poisonAmount = poisonAmount;
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // Finds the enemy thats in range and with the tag "Enemy"
        if (collision.CompareTag("Enemy"))
        {
            enemy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Reset the enemy reference when it exits the trigger.
        if (collision.CompareTag("Enemy"))
        {
            enemy = null;
        }
    }
}
