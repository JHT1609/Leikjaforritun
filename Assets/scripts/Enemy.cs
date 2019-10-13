using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* refrenc https://www.youtube.com/watch?v=1QfxdUpVh5I */

public class Enemy : MonoBehaviour
{
    private Transform target;
    public float speed;
    public int health;
    private float dazedTime;
    public float startDazedTime;
    
    /*enemy attack does not work*/

    // private Animator anim;
    public GameObject bloodEffect;
    public PlayerController player;
    private BoxCollider2D collider;

    public Transform Target
    {
        get
        {
            return target;
        }
        set
        {
            target = value;
        }
    }
    

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<PlayerController>();
        collider = GetComponent<BoxCollider2D>();
        /*anim = GetComponent<Animator>();
          anim.SetBool("isRunning", true);*/ 
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();

        if (dazedTime <= 0)
        {
            speed = 1;
        }
        else
        {
            speed = 0;
            dazedTime -= Time.deltaTime;
        }

        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    void TakeDamage(int damage)
    {
        dazedTime = startDazedTime;
        Instantiate(bloodEffect, transform.position, Quaternion.identity);
        health -= damage;
        Debug.Log("damage");
    }


    private void FollowTarget()
    {
        if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
        }
    }
}
