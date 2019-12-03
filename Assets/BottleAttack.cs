using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BottleAttack : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        if (Input.GetKey(KeyCode.Z))
        {
            gameObject.SetActive(true);
        }

    }

    bool flag = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            flag = !flag; //set flag to opposite value
        }


        if (flag)
        {
            Debug.Log("yes");
        }

        else
        {
            Debug.Log("no");
        }
    }
}
