using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EnemyHealthSystemScript : MonoBehaviour
{
    public float health = 20f;
    //public float moveSpeed = 2.0f; // Adjust the speed of the movement.
    //public float upDistance = 10.0f; // Adjust the distance the object moves up and down.
    public float damageTaken;
    public int poisonAmount;
    public Material originalMaterial;
    public Material overlayMaterial;
    public SpriteRenderer spriteRenderer;
    public bool isPoisoned = false;
    public int deathPay;
    [SerializeField] GameManager GameManager;

    private Vector3 startPosition;
    private string damageType;
    private float poisonTimer = 1f;
    private float damageColorTimer = 0.5f;
    private int poisonCounter;
    private float time = 0f;

    [SerializeField] private BreadMover BM;

    private void Start()
    {
        BM = GetComponent<BreadMover>();
        startPosition = transform.position;

        GameManager = FindAnyObjectByType<GameManager>();
    }

    private void Update()
    {
        time = time + 1 * Time.deltaTime;

        if (damageType == "Ketchup")
            DoKetchupDamage();
        if (damageType == "Mustard")
            DoMustardDamage();
        if (damageType == "Mayo")
            DoMayoDamage();
        if (damageType == "Egg")
            DoEggDamage();

        if (health <= 0)
        {
            die();
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

        if (collision.CompareTag("Egg"))
            damageType = "Egg";
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

    void DoEggDamage()
    {
        if (damageTaken > 0)
        {
            health -= damageTaken;
            damageTaken = 0;
        }
    }

    void die()
    {
        GameManager.GetComponent<GameManager>().RemoveBread(this.GameObject());
        GameManager.GetComponent<GameManager>().AddCrumbs(deathPay);
        Destroy(this.gameObject);
    }

    public void EndDie()
    {
        GameManager.GetComponent<GameManager>().RemoveBread(this.GameObject());

    }
}
