using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    //Store a reference to all sub player scripts
    [SerializeField]
    internal PlayerInputScript inputScript;

    [SerializeField]
    internal PlayerMovementScript movementScript;

    [SerializeField]
    internal PlayerCollisionScript collisionScript;

    //Main Player Properties
    [Header("Player Properties")]
    internal Rigidbody2D body;
    internal Animator anim;
    public float moveSpeed;
    public float jumpForce;
    

    private void Awake()
    {
        //Grab References for Rigidbody and Animator from object
        body = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    private void Start()
    {
        print("Main PlayerScript Starting");
    }
}
