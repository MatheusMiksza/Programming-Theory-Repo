using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player02 : MonoBehaviour
{

    private PlayerController playerController;


    private void Awake()
    {
        playerController = gameObject.GetComponentsInChildren<PlayerController>()[0];
    }
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Keypad0))
        {
            playerController.Punch();
        }
        if (Input.GetKeyDown(KeyCode.RightControl))
        {
            playerController.Kick();
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            playerController.MoveFoward();
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            playerController.MoveBackward();
        }
        else
        {
            playerController.Idle();
        }
    }
}
