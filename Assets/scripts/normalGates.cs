using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class normalGates : MonoBehaviour
{
    private bool onGate = false;
    public Animator anim;
    // Þetta er animation fyrir hurðir sem eru ekki að færa mann á nýtt level
    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("HurdOpnar", true);
            onGate = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            anim.SetBool("HurdOpnar", false);
            onGate = false;
        }
    }
}
