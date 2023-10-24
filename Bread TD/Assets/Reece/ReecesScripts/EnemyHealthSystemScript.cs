using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyHealthSystemScript : MonoBehaviour
{
    public float health = 20f;
    public float moveSpeed = 2.0f; // Adjust the speed of the movement.
    public float upDistance = 10.0f; // Adjust the distance the object moves up and down.
    public float damageTaken;
    public int poisonAmount;
    public Material originalMaterial;
    public Material overlayMaterial;
    public SpriteRenderer spriteRenderer;
    public bool isPoisoned = false;

    private Vector3 startPosition;
    private string damageType;
    private float poisonTimer = 1f;
    private float damageColorTimer = 0.5f;
    private int poisonCounter;
    private float time = 0f;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        time = time + 1f * Time.deltaTime;

        if (damageType == "Ketchup")
            DoKetchupDamage();
        if (damageType == "Mustard")
            DoMustardDamage();
        if (damageType == "Mayo")
            DoMayoDamage();
        
        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        //float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * upDistance;
        //transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ketchup"))
            damageType = "Ketchup";
        
        if (collision.CompareTag("Mustard"))
            damageType = "Mustard";

        if (collision.CompareTag("MayoAOE"))
            damageType = "Mayo";
    }

    void DoKetchupDamage()
    {
        if (damageTaken > 0)
        {
            //Debug.Log("Taken Ketchup Damage");
            health -= damageTaken;
            damageTaken = 0;
        }
    }

    void DoMustardDamage()
    {
        if (damageTaken > 0)
        {
            //Debug.Log("Taken Mustard Damage");
            if (poisonCounter <= poisonAmount)
            {
                if (time >= poisonTimer)
                {
                    health -= damageTaken;

                    // Assign the overlay material to the renderer.
                    spriteRenderer.material = overlayMaterial;

                    poisonCounter++;
                    time = 0f;
                }
            }
            else
            {
                damageTaken = 0;
                isPoisoned = false;
            }
                
        }
    }

    void DoMayoDamage()
    {
        if (damageTaken > 0)
        {
            //Debug.Log("Taken Mayo Damage");
            health -= damageTaken;
            damageTaken = 0;
        }
    }
}
