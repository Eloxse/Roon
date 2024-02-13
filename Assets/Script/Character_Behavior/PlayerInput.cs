using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    public Vector2 movement = Vector2.zero;

    public bool interaction_Chest = false;
    public bool interaction_Block = false;
    public bool jump = false;
    
    // Update is called once per frame
    void Update()
    {
        movement.Set(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        jump = Input.GetButton("Jump");
        interaction_Chest = Input.GetButton("Interaction_Chest");
        interaction_Block = Input.GetButton("Interaction_Block");
    }
}
