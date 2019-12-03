using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcontroler : MonoBehaviour
{
    public int index;
    public string levelName;
    public Animator animator;

    private bool onDoor = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        /* hér er verið að skoða hvort maður ýtti á "e" og ef það er þannig þá er sent mann á levelið sem er búið að selecta*/
        if ((onDoor == true) && (Input.GetKeyDown("e")))
        {

            //Loading level with build index
            SceneManager.LoadScene(index);

            //Loading level with build name
            SceneManager.LoadScene(levelName);

        }
    }
    /* hér er kveikt á animationi*/ 
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("HurdOpnar", true);
            onDoor = true;
        }

    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            animator.SetBool("HurdOpnar", false);
            onDoor = false;
        }
    }

}
