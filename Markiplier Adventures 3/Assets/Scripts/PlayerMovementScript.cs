using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//====================================================
// The code in this script manages all player movement
//====================================================
public class PlayerMovementScript : MonoBehaviour
{
    [SerializeField]
    PlayerScript playerScript;

    private bool facingRight;

    internal float fallMultiplier = 2.5f;
    internal float lowJumpMultiplier = 2f;

    void Start()
    {
        print("PlayerMovementScript Starting");
    }

    private void Update()
    {
        if (playerScript.inputScript.isUpPressed && playerScript.collisionScript.grounded)
        {
            PlayerJump();
        }
    }

    void FixedUpdate()
    {
        // Fall Physics
        if (playerScript.collisionScript.grounded == false)
        {
            if (playerScript.body.velocity.y < 0)
            {
                playerScript.body.velocity += Vector2.up * Physics.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
            }
            else if (playerScript.body.velocity.y > 0 && playerScript.inputScript.isUpPressed == false)
            {
                playerScript.body.velocity += Vector2.up * Physics.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
            }
        }

        //Check the input manager for button press state
        if (playerScript.inputScript.isRightPressed)
        {
            MovePlayerRight();
        }
        else if(playerScript.inputScript.isLeftPressed)
        {
            MovePlayerLeft();
        }
        else
        {
            StopMovement();
        }
    }

    private void MovePlayerLeft()
    {
        if (!facingRight)
        {
            Flip();
        }
        // Animate run
        playerScript.anim.SetBool("run", true);
        playerScript.anim.SetBool("idle", false);
        
        playerScript.body.velocity = new Vector2(-playerScript.moveSpeed, playerScript.body.velocity.y);
    }

    private void MovePlayerRight()
    {
        if (facingRight)
        {
            Flip();
        }
        // Animate run
        playerScript.anim.SetBool("run", true);
        playerScript.anim.SetBool("idle", false);
        
        playerScript.body.velocity = new Vector2(playerScript.moveSpeed, playerScript.body.velocity.y);
    }

    private void PlayerJump()
    {
        playerScript.body.velocity = new Vector2(playerScript.body.velocity.x, playerScript.jumpForce);
    }

    private void StopMovement()
    {
        // Animate idle
        playerScript.anim.SetBool("run", false);
        playerScript.anim.SetBool("idle", true);

        // Stop horizontal movement
        playerScript.body.velocity = new Vector2(0, playerScript.body.velocity.y);
    }

    // Flips Sprite Image
    private void Flip()
    {
        facingRight = !facingRight;
        transform.Rotate(0f, 180f, 0f);
    }
}
