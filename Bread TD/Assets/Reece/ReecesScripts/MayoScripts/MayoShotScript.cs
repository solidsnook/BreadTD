using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MayoShotScript : MonoBehaviour
{
    // Declaring Variables
    public GameObject target;
    public float shotSpeed;          // How fast the shot can move
    public float mayoDamage;         // How much damage the shot does
    public float aoeRange;                // How big the area of damage is 

    //private bool isHit = false; 

    // Update is called once per frame
    void Update()
    {
        // If an Enemy doesnt exist dont do anything
        if (target != null)
        {
            // Direction of closest Bread
            Vector3 direction = target.transform.position - transform.position;
            direction.Normalize();

            // Move Shot to Bread
            transform.Translate(direction * shotSpeed * Time.deltaTime);
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
            GameObject aoeAreaPrefab = Resources.Load("AOEAreaPrefab") as GameObject;

            if (aoeAreaPrefab != null)
            {
                GameObject currentAoe = Instantiate(aoeAreaPrefab, collision.transform.position, Quaternion.identity);
                AOEAreaScript aoe = currentAoe.AddComponent<AOEAreaScript>();

                aoe.mayoDamage = mayoDamage;
                aoe.aoe = aoeRange;
            }

            Destroy(this.gameObject);
        }

    }

    /*
    void OnTriggerStay2D(Collider2D collision)
    {
        if (isHit)
        {
            if (collision.CompareTag("Enemy"))
            {
                EnemyHealthSystemScript bread = collision.GetComponent<EnemyHealthSystemScript>();
                bread.damageTaken = mayoDamage;
                Destroy(this.gameObject);
            }
        }
    }
    */

    /*
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            if (aoe > 0)
            {
                var hitColliders = Physics2D.OverlapCircleAll(transform.position, aoe);
                foreach (var hitCollider in hitColliders)
                {
                    var enemy = hitCollider.GetComponent<EnemyHealthSystemScript>();
                    if (enemy)
                    {
                        var closestPoint = hitCollider.ClosestPoint(transform.position);
                        var distance = Vector3.Distance(closestPoint, transform.position);

                        enemy.damageTaken = mayoDamage;
                    }
                }
            }
            else
            {
                var enemy = collision.GetComponent<Collider>().GetComponent<EnemyHealthSystemScript>();
                if (enemy)
                {
                    enemy.damageTaken = mayoDamage;
                }
            }
            Destroy(this.gameObject);
        }
           
    }
    */
}
