using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//====================================================
// The code in this script checks for button/key input
//====================================================
public class PlayerInputScript : MonoBehaviour
{
    [SerializeField]
    PlayerScript playerScript;

    internal bool isLeftPressed;
    internal bool isRightPressed;
    internal bool isUpPressed;
    internal bool isDownPressed;


    void Start()
    {
        print("PlayerInputScript Starting");
    }

    void Update()
    {
        // Left Button
        if(Input.GetKey(KeyCode.A))
        {
            isLeftPressed = true;
        }
        else
        {
            isLeftPressed = false;
        }
        // Right Button
        if (Input.GetKey(KeyCode.D))
        {
            isRightPressed = true;
        }
        else
        {
            isRightPressed = false;
        }
        // Right Button
        if (Input.GetKey(KeyCode.W))
        {
            isUpPressed = true;
        }
        else
        {
            isUpPressed = false;
        }
    }

}
