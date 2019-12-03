using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class chest : MonoBehaviour
{
    public Animator animator;

    private bool onkista = false;
    private bool chest_open = false;


    public GameObject Euphoria;
    public Transform spawnlocation;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }
    /*animatio sem lokar kistuni*/
    void CloseAnimation()
    {
        animator.Play("kista_lokar");
        animator.SetBool("kistaOpnar", false);
        Debug.Log("kista lokar");
        chest_open = false;
    }

    // Update is called once per frame
    void Update()
    {
        /*takki til að opna kistuna og kveikja á animationi*/
        if (onkista && !chest_open && Input.GetKeyDown(KeyCode.E))
        {
            animator.Play("kista_opnar");
            animator.SetBool("kistaOpnar", true);
            Debug.Log("open kista");
            chest_open = true;
            GameObject euphoria = Instantiate(Euphoria, spawnlocation);
        }
        else if(onkista && chest_open && Input.GetKeyDown(KeyCode.E))
        {
            CloseAnimation();
        }
    }
    //verið að skoða hvort það er hægt að opna kistuna
    private void OnTriggerEnter2D(Collider2D other)
    {
        if ((other.CompareTag("Player")))
        {
            onkista = true;
        }
    }
    //notað þanig að ef maður labbar í burtu þá lokast kistan
    private void OnTriggerExit2D(Collider2D other)
    {
        if ((other.gameObject.tag == "Player") && chest_open)
        {
            CloseAnimation();
            onkista = false;
        }
    }
}
