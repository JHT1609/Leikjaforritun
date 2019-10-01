using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class levelcontroler : MonoBehaviour
{
    public int index;
    public string levelName;

    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log(Input.GetKeyDown("e"));
        if ((other.CompareTag("Player")) && (Input.GetKeyDown("e")))
        {
            
                //Loading level with build index
                SceneManager.LoadScene(index);

                //Loading level with build name
                SceneManager.LoadScene(levelName);
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {



    }

}
