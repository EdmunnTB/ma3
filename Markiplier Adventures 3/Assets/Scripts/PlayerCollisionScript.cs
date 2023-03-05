using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//========================================================
// The code in this script manages player collision checks
//========================================================
public class PlayerCollisionScript : MonoBehaviour
{
    [SerializeField]
    PlayerScript playerScript;

    [SerializeField]
    private int groundLayer;

    public bool grounded;

    void Start()
    {
        print("PlayerCollisionScript Starting");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.layer.Equals(groundLayer))
        {
            grounded = true;
            playerScript.anim.SetBool("idle", true);
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(groundLayer))
        {
            grounded = true;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.layer.Equals(groundLayer))
        {
            grounded = false;
            playerScript.anim.SetBool("run", false);
            playerScript.anim.SetBool("idle", false);
        }
    }


}
