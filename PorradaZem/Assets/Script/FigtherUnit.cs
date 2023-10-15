using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigtherUnit : MonoBehaviour
{
    [SerializeField]
    private Animator animator;

   

    protected GameObject fighter { get; set; }
    protected Rigidbody playerRb { private get; set; }



    // Start is called before the first frame update
    void Awake()
    {
        animator.Play("Idle");
        
    }

   

    public virtual void Punch()
    {
        
        animator.SetTrigger("PunchTrigger");
    }

    public virtual void Kick()
    {
        animator.SetTrigger("KickTrigger");
    }

    public virtual void MoveFoward()
    {
        animator.SetBool("Walk Backward", false);
        animator.SetBool("Walk Forward", true);
    }
    public virtual void MoveBackward()
    {
        animator.SetBool("Walk Forward", false);
        animator.SetBool("Walk Backward", true);
    }
    public virtual void Idle()
    {
        animator.SetBool("Walk Forward", false);
        animator.SetBool("Walk Backward", false);
        
    }

    public virtual void Jump()
    {
        
    }
}
