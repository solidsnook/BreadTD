using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class SimpleMoveScript : MonoBehaviour
{
    public float health = 20f;
    public float moveSpeed = 2.0f; // Adjust the speed of the movement.
    public float upDistance = 10.0f; // Adjust the distance the object moves up and down.
    public float damageTaken;
    private Vector3 startPosition;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        if (damageTaken > 0)
        {
            health -= damageTaken;
            damageTaken = 0;
        }

        if (health <= 0)
        {
            Destroy(this.gameObject);
        }

        float newY = startPosition.y + Mathf.Sin(Time.time * moveSpeed) * upDistance;
        transform.position = new Vector3(transform.position.x, newY, transform.position.z);
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Ketchup"))
        {
            DoKetchupDamage();
        }
        
        if (collision.CompareTag("Mustard"))
        {

        }

        if (collision.CompareTag("Mayo"))
        {

        }
    }

    void DoKetchupDamage()
    {

    }

    void DoMustardDamage()
    {

    }

    void DoMayoDamage()
    {

    }
}
