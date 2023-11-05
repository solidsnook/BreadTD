using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class ShotScript : MonoBehaviour
{
    // Declaring Variables
    public GameObject target;
    public float shotSpeed;     // How fast the shot can move
    public float Damage;        // How much damage the shot does
    public float aoeRange;      // How big the area of damage is 
    public int poisonAmount;    // How many times the damage is taken

    // Update is called once per frame
    void Update()
    {
        // If an Enemy doesnt exist dont do anything
        if (target != null)
        {
            // Direction of closest Bread
            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();

            // Point towards bread


            // Move Shot to Bread
            transform.Translate(direction * shotSpeed * Time.deltaTime);
            //transform.LookAt(target.transform.position, Vector3.forward);
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            EnemyHealthSystemScript breadScript = target.GetComponent<EnemyHealthSystemScript>();
            breadScript.damageTaken = Damage;

            if (breadScript.isPoisoned == false)
            {
                breadScript.damageTaken = Damage;
                breadScript.poisonAmount = poisonAmount;
                breadScript.isPoisoned = true;
            }
        
            if (aoeRange > 0)
            {
                GameObject aoeAreaPrefab = Resources.Load("AOEAreaPrefab") as GameObject;

                if (aoeAreaPrefab != null)
                {
                    GameObject currentAoe = Instantiate(aoeAreaPrefab, collision.transform.position, Quaternion.identity);
                    AOEAreaScript aoe = currentAoe.AddComponent<AOEAreaScript>();

                    aoe.mayoDamage = Damage;
                    aoe.aoe = aoeRange;
                }
            }

            Destroy(this.gameObject);
        }
    }
}
