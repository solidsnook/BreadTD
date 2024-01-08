using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using Unity.VisualScripting;
using UnityEditor;
//using UnityEditor.Animations;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;
using UnityEngine.UI;

public class TowerScript : MonoBehaviour
{
    // Declaring Variables
    public float damage;            // How much damage the shot does
    public float speed;             // How fast the shot can move
    public float fireRate;          // How fast the tower can shoot
    public float attackRange;       // How far can the enemy be for the tower to shoot
    public int cost;                // How much the tower costs to place down
    public int sellValue;           // How much you can sell the tower for
    public int towerLevel;          // What tower level the tower is currently on
    public int shotAmount;          // If the tower runs out of shots it is destroyed
    public GameObject Shot;         // Prefab for the Ketchup Shot
    public float aoe;               // How big the area of damage is 
    public int poisonAmount;        // How many times the damage is taken
    private List<GameObject> enemyList;
    private float time = 0f;
    public Animator animator;
    public Slider shotBar;
    public Gradient gradient;
    public Image fill;

    //Audio Variable Declaration
    public AudioSource ShootSoundSource;
    public AudioClip ShootSoundEffect;

    //private TowerManager towerManager;
    private GameObject CurrentButton;

    void Start()
    {
        enemyList = new List<GameObject>();

        shotBar.maxValue = shotAmount;
        fill.color = gradient.Evaluate(1f);
        //towerManager.SelectedButton = CurrentButton;
    }

    // Update is called once per frame
    void Update()
    {
        time = time + 1f * Time.deltaTime;

        shotBar.value = shotAmount;
        fill.color = gradient.Evaluate(shotBar.normalizedValue);

        // Updates the attackRange variable to the radius of the collider so it can be easily changed
        GetComponent<CircleCollider2D>().radius = attackRange;

        if (enemyList.Count != 0)
        {
            // Delay until next shot
            if (time >= fireRate)
            {
                Shoot();
                time = 0f;
            }
        }

        if (shotAmount <= 0)
        {
            //set ocupied to false
            //CurrentButton.GetComponent<ButtonPlacerScript>().SetOcupied(false);
            //CurrentButton.GetComponent<Image>().sprite = towerManager.NotOccupied;
            //CurrentButton.GetComponent<ButtonPlacerScript>().OcupiedTower = null;

            //delete tower
            //Destroy(this.gameObject);
        }
    }
    void Shoot()
    {
        // If the tower runs out of shots it is destroyed
        if (shotAmount > 0)
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
            shot.target = enemyList[0];
            shot.aoeRange = aoe;
            shot.poisonAmount = poisonAmount;

            shotAmount--;
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {

        // Finds the enemy thats in range and with the tag "Enemy"
        if (collision.CompareTag("Enemy"))
        {
            enemyList.Add(collision.gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Reset the enemy reference when it exits the trigger.
        if (collision.CompareTag("Enemy"))
        {
            enemyList.Remove(collision.gameObject);
        }
    }
}
