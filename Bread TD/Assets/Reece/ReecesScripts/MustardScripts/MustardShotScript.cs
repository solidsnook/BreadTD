using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MustardShotScript : MonoBehaviour
{
    // Declaring Variables
    public GameObject target;
    public float shotSpeed;        // How fast the shot can move
    public float mustardDamage;    // How much damage the shot does
    public int poisonAmount;       // How many times the damage is taken


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
        if (collision.CompareTag("breadBasic") || collision.CompareTag("breadSpeedy") || collision.CompareTag("breadICannotRemember"))
        {
            EnemyHealthSystemScript breadScript = target.GetComponent<EnemyHealthSystemScript>();

            if (breadScript.isPoisoned == false)
            {
                breadScript.damageTaken = mustardDamage;
                breadScript.poisonAmount = poisonAmount;
                breadScript.isPoisoned = true;
            }

            Destroy(this.gameObject);
        }
    }
}
