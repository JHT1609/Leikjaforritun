using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    private GameObject Arrow;
    private float timeBtwAttack;
    public float startTimeBtwAttack;

    [Space(10)]
    public Transform attackPos;
    public LayerMask whatIsEnemies;
    public float attackRange;
    public int damage;

    // Update is called once per frame
    void Update()
    {
        if(timeBtwAttack <= 0) { //finnur hvort hægt er að skjóta
            // gerir árás
            if (Input.GetKey(KeyCode.Space)) {
                Collider2D[] enemiesToDamage = Physics2D.OverlapCircleAll(attackPos.position, attackRange, whatIsEnemies);  //finnur þegar overlap er milli örva og enemy
                for (int i = 0; i < enemiesToDamage.Length; i++) {
                    enemiesToDamage[i].GetComponent<Enemy>().health -= damage;  //tekur enemy health
                }
            }
            timeBtwAttack = startTimeBtwAttack;
        }else {
            timeBtwAttack -= Time.deltaTime;    //bilið milli skota
        }
    }
    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPos.position, attackRange);
    }
}
