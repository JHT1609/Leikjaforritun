using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Vector2 movementDirection;

    // Update is called once per frame
    void Update()
    {
        
    }

    void ProcessInputs() {
        movementDirection = new Vector2(player.GetAxis("Horizontal"), player.GetAxis("Vertical"));
    }
}
