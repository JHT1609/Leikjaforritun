using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* refrence https://www.youtube.com/watch?v=1QfxdUpVh5I */

public class Enemy : MonoBehaviour
{
    private Transform target;
    private Rigidbody2D myrigidbody2D;
    public float speed;
    public int health;
    private float dazedTime;
    public int damage;
    public float thrust;

    private Rigidbody2D rb;
    

    // private Animator anim;
    public GameObject bloodEffect;
    public PlayerController player;

    // hér er verið að leta af target sem er playerinn
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
        
    }

    // Update is called once per frame
    void Update()
    {
        FollowTarget();

        // hér er verið að skoða hvort enemyin á að deyja eða ekki
        if (health <= 0) {
            Destroy(gameObject);
        }
    }

    // hér er verið að skoða hvort enemy á að meiða playerinn
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player") other.GetComponent<Enemy>().health -= damage;
    }

    // hérna er skoðað hvort playerinn er inn í range sem er með collider og ef playerinn er í trigger colliderinum á fer hann í áttina að playerinnum
    private void FollowTarget()
    {
         if(target != null)
        {
            transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            
        }
    }
}
