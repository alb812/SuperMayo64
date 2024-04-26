using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Supplementary Jump Script
// Attach this to the player controller - Should also have MarioController attached. 
// This adds some game feel to the jump, allowing you to hold the jump button to jump slightly higher by manipulating the jumpForce via gravity. 
public class PlayerJump : MonoBehaviour
{
    // PUBLIC ASSIGNED IN INSPECTOR - values to determine how quickly you fall after jumping (low and max jump)
    // careful of RigidBody mass - can really mess it up if you change mass at all - keep Mass at 1 for now 
    public float fallMultiplier = 3.25f;       
    public float lowJumpMultiplier = 3.1f;

    Rigidbody rb;
    Mario_Controller player;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        player = FindObjectOfType<Mario_Controller>();
    }

    void Update()
    {
        if (rb.velocity.y < 0)
        {
            //Maximum jump/normal jump
            rb.velocity += Vector3.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //if you let go of jump early, you jump shorter
        else if (rb.velocity.y > 0 && !Input.GetKey(KeyCode.Space) && player.noBetterJump == false)
        {
            rb.velocity += Vector3.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }
}