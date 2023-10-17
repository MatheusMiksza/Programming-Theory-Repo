using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player01 : MonoBehaviour
{
    private PlayerController playerController;


    private void Awake()
    {
        playerController = gameObject.GetComponentsInChildren<PlayerController>()[0];
    }
    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerController.Punch();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            playerController.Kick();
        }
        if (Input.GetKey(KeyCode.S))
        {
           playerController.Crounch(true);
        }
        if (Input.GetKeyUp(KeyCode.S))
        {
            playerController.Crounch(false);

        }
        else if (Input.GetKey(KeyCode.D))
        {
            playerController.MoveFoward();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            playerController.MoveBackward();
        }
        else
        {
            playerController.Idle();
            
        }
    }
    
}
