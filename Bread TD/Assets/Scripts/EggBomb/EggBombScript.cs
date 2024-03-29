using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class EggBombScript : MonoBehaviour
{
    // Declaring Public Variables
    public float damage;          // How much damage the shot does
    public float aoe;             // How big the explosion is
    public int cost;            // How much the tower costs to place down
    public float fuseTime;        // How long until the bomb explodes
    public Animator animator;     // This is the animator for the egg bomb
    public AudioSource EggFuseSoundSource;
    public AudioSource EggSplatSoundSource;
    public AudioClip EggSplatSoundEffect;

    //public Sprite lit;            // Temp
    //public Sprite blow;           // Temp

    // Declaring Private Variables
    private GameObject enemy;
    private bool isPlayed;

    void Start()
    {
        isPlayed = false;
        // Plays Egg Bomb Lit animation
        //this.GetComponent<SpriteRenderer>().sprite = lit;
    }

    // Update is called once per frame
    void Update()
    {
        // Updates the radius depending on the aoe variable
        this.GetComponent<CircleCollider2D>().radius = aoe;

        // Blow Up Function
        BlowUp();
    }

    // This will start a timer to blow up as soon as it is placed
    private void BlowUp()
    {
        if (fuseTime <= 0)
        {
            // Plays Egg Bomb Explosion animation o7
            animator.SetTrigger("IsExploding?");
            EggFuseSoundSource.Stop();

            if (!isPlayed)
            {
                EggSplatSoundSource.PlayOneShot(EggSplatSoundEffect);
                isPlayed = true;
            }

            Debug.Log("BLOW");

            // If the enemy exists apply damage to it
            if (enemy != null)
            {
                EnemyHealthSystemScript breadScript = enemy.GetComponent<EnemyHealthSystemScript>();
                breadScript.damageTaken = damage;
            }

            //Destroy(this.gameObject);
        }
        else
        {
            // Starts count down until it blows up
            fuseTime -= Time.deltaTime;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        // Takes any bread withing range of the collider and adds it to enemy
        if (collision.CompareTag("Enemy"))
        {
            enemy = collision.gameObject;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        // Removes enemy if they exit collider
        if (collision.CompareTag("Enemy"))
        {
            enemy = null;
        }
    }

    void DestroyObject()
    {
        Destroy(this.gameObject);
    }

}
