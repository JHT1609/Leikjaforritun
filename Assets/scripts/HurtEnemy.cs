using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemy : MonoBehaviour
{

    public int damage;
    // þetta allt er til að segja hvað óvinnirnir eiga að meipast mikið við snertingu á örvunum 
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Enemy")
        {
            Destroy(gameObject);
            other.GetComponent<Enemy>().health -= damage;
        }
        else if (other.tag == "Boss1")
        {
            Destroy(gameObject);
            other.GetComponent<Enemy>().health -= damage;
        }
        else if (other.tag == "Boss2")
        {
            Destroy(gameObject);
            other.GetComponent<Enemy>().health -= damage;
        }
        else if (other.tag == "Boss3")
        {
            Destroy(gameObject);
            other.GetComponent<Enemy>().health -= damage;
        }
        else if (other.tag == "wall")
        {
            Destroy(gameObject);
        }
    }
}
