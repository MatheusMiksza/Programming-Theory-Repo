using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FigtherUnit : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    
    protected PlayerController player02Controller { get; set; }

    protected Rigidbody playerRb { get; set; }
    protected CapsuleCollider playerCollider;
    private float life = 100;
    protected GameObject fighter { get; set; }

    protected bool isGround = true;
    public bool gameOver { get; private set; }

    public float p_life { get { return life; }
                          private set {
                        if (value < 0)life = 0;
                        else life = value; 
                        } }
    private float impulse = 35;


    // Start is called before the first frame update
    void Awake()
    {
        animator.Play("Idle");      
        gameOver = false;
        
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
        if (isGround)
        {
            animator.SetBool("Walk Backward", false);
            animator.SetBool("Walk Forward", true);           
        }
    }
    public virtual void MoveBackward()
    {
        if (isGround)
        {
            animator.SetBool("Walk Forward", false);
            animator.SetBool("Walk Backward", true);            
        }
    }
    public virtual void Idle()
    {
        animator.SetBool("Walk Forward", false);
        animator.SetBool("Walk Backward", false);
    }

    public void IsGround(bool b)
    {
        if (b && !isGround) { animator.SetTrigger("IsGround"); }
        else animator.ResetTrigger("IsGround");
        isGround = b;        
    }

    public virtual void Crounch(bool b)
    {
        animator.SetBool("Crounch", b);
        animator.SetBool("Walk Forward", false);
        animator.SetBool("Walk Backward", false);
        playerCollider.isTrigger = b;
    }

    public void Hit(float hit)
    {
        
        animator.SetTrigger("Hit");
        AddLife(hit);
        playerRb.AddForce(Vector3.back * impulse * gameObject.transform.right.x, ForceMode.Impulse);

        if (life <= 0) Stuned(true);

        Debug.Log(life);
    }

    private void Stuned(bool b)
    {
        if(p_life <= 0 && animator.GetBool("Stuned"))
            animator.SetBool("GameOver", b);
        else
            animator.SetBool("Stuned", b);
    }
    
    public void AddLife(float hit)
    {
        p_life += hit;
    }

}
