using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class FigtherUnit : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private ParticleSystem hitParticle;
    
   

    
    protected PlayerController player02Controller { get; set; }

    protected Rigidbody playerRb { get; set; }
    protected CapsuleCollider playerCollider;
    private float life = 100;
    public Slider lifeBar;
    protected GameObject fighter { get; set; }
    public Vector3 enenyPos;


    protected bool isGround = true;
    public bool gameOver { get; private set; }

    public float p_life { get { return life; }
                          private set {
                        if (value < 0)life = 0;
                        else life = value; 
                        } }
    private float impulse = 35;

    public float distance { get; private set; }
    private float maxDist = 10f;
    public GameManager gameManager { get; private set; }


    // Start is called before the first frame update
    void Awake()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        animator.Play("Idle");      
        gameOver = false;
        
    }
    public virtual void Punch()
    {
        if (gameManager.isGameActive)
            animator.SetTrigger("PunchTrigger");        
    }
    public virtual void Kick()
    {
        if (gameManager.isGameActive)
            animator.SetTrigger("KickTrigger");
    }

    public virtual void MoveFoward()
    {
        SetDistance();
        if (isGround && distance < maxDist && gameManager.isGameActive)
        {
            animator.SetBool("Walk Backward", false);
            animator.SetBool("Walk Forward", true);           
        }
    }
    public virtual void MoveBackward()
    {
        SetDistance();
        if (isGround && distance < maxDist && gameManager.isGameActive)
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
    public void HitParticles(Collision collision)
    {
        hitParticle.transform.position = collision.transform.position;
        hitParticle.Play();
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
        if (p_life <= 0 && animator.GetBool("Stuned"))
        {
            animator.SetBool("GameOver", b);
            gameManager.GameOver();
        }
        else
            animator.SetBool("Stuned", b);
    }
    public void IniciaLifeBar(Slider bar)
    {
        lifeBar = bar;
        lifeBar.value = p_life;
        lifeBar.gameObject.SetActive(true);
    }

    public void AddLife(float hit)
    {
        p_life += hit;
        lifeBar.value = p_life;
    }

    public void SetDistance()
    {      

        distance = Vector3.Distance(transform.position, enenyPos);
        Debug.Log(enenyPos);
    }

    public virtual string GetName()
    {
        return "FigthUnit";
    }

    public virtual string GetData()
    {
        return "";
    }

}
