using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public Animator animator;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay2D(Collider2D other)
    {
        if ((other.CompareTag("Player")) && (Input.GetKeyDown("e")))
        {
            animator.Play("kista_opnar");
            animator.SetBool("kistaOpnar", true);
            Debug.Log("open kista");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        animator.Play("kista_lokar");
        animator.SetBool("kistaOpnar", false);
        Debug.Log("kista lokar");
    }
}
