using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigtherUnit : MonoBehaviour
{
    public Animator animator;

    private bool isIdle = true;

    protected GameObject fighter { get; set; }


    // Start is called before the first frame update
    void Awake()
    {
        animator.Play("Idle");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {            
            Punch();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            Kick();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            MoveFoward();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            MoveBackward();
        }
        else
        {
            Idle();
        }
        
    }

    void Punch()
    {
        
        animator.SetTrigger("PunchTrigger");
    }

    void Kick()
    {
        animator.SetTrigger("KickTrigger");
    }

    void MoveFoward()
    {
        animator.SetBool("Walk Backward", false);
        animator.SetBool("Walk Forward", true);
    }
    void MoveBackward()
    {
        animator.SetBool("Walk Forward", false);
        animator.SetBool("Walk Backward", true);
    }
    void Idle()
    {
        animator.SetBool("Walk Forward", false);
        animator.SetBool("Walk Backward", false);
        isIdle = true;
    }
}
