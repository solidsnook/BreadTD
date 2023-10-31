using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AOEAreaScript : MonoBehaviour
{
    public float mayoDamage;
    public float aoe;

    // A variable to count the number of collisions.
    private int collisionCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        // GetComponent<CircleCollider2D>().radius = aoe;
    }

    // Update is called once per frame
    void Update()
    {
        // Log the collision count each frame.
        //Debug.Log("Number of Collisions: " + collisionCount);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            // Increment the collision count.
            collisionCount++;

            // Check if the distance between the AOE center and the enemy is within the AOE radius.
            float distance = Vector2.Distance(transform.position, collision.transform.position);
            if (distance <= aoe)
            {
                // Assuming the enemy has a script like "EnemyScript" with a "TakeDamage" method.
                EnemyHealthSystemScript enemy = collision.GetComponent<EnemyHealthSystemScript>();
                if (enemy != null)
                {
                    enemy.damageTaken = mayoDamage;
                    Destroy(this.gameObject);
                }
            }
        }
    }
}
