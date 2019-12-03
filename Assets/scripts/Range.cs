using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Range : MonoBehaviour
{
    private Enemy parent;

    //þetta er allt svo óvinurinn getur labbað að playerinnium þannig það er verið að taka eftir því hvort playerinn er í trigger colliderinum 
    private void Start()
    {
        parent = GetComponentInParent<Enemy>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            parent.Target = other.transform;
        }
    }
}
