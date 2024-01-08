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
    public Rigidbody2D rb;
    public Animator animator;
    public AudioSource ShotSplatSoundSource;
    public AudioClip ShotSplatSoundEffect;

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
            float angle = Mathf.Atan2(target.transform.position.y - transform.position.y, target.transform.position.x - 
                transform.position.x) * Mathf.Rad2Deg - 90;

            transform.rotation = Quaternion.Euler(new Vector3(0f, 0f, angle));

            // Move Shot to Bread
            rb.velocity = direction * shotSpeed;
            //transform.Translate(direction * shotSpeed * Time.deltaTime);
            //transform.LookAt(target.transform.position, Vector3.forward);
        }
        else
        {
            rb.velocity = Vector3.zero;

            // Plays Splat Animation
            animator.SetTrigger("IsSplatting?");
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject == target)
        {
            // Plays Splat Animation
            animator.SetTrigger("IsSplatting?");

            ShotSplatSoundSource.PlayOneShot(ShotSplatSoundEffect);

            if (target == null) return;
            EnemyHealthSystemScript breadScript = target.GetComponent<EnemyHealthSystemScript>();

            breadScript.damageTaken = Damage;

            if (breadScript.isPoisoned == false)
            {
                breadScript.damageTaken = Damage;
                breadScript.poisonAmount = poisonAmount;
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
        }
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }

    void ScaleUp()
    {
        this.transform.localScale = new Vector3(0.4f, 0.4f, 0.4f);
    }
}
