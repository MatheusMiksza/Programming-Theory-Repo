using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;


// INHERITANCE
// CLASSE PAI
public class FigtherUnit : MonoBehaviour
{
    [SerializeField]
    private Animator animator;
    [SerializeField]
    private ParticleSystem hitParticle;
    private CharacterController character;



    // ENCAPSULATION
    protected PlayerController player02Controller { get; set; }

    protected Rigidbody playerRb { get; set; }
    protected CapsuleCollider playerCollider;
    private float life = 100;
    public Slider lifeBar;
    protected GameObject fighter { get; set; }
    public Vector3 enenyPos;
    private Vector3 input;


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
    public MainManager mainManager { get; private set; }


    // Start is called before the first frame update
    void Awake()
    {
        if (SceneManager.GetActiveScene().buildIndex != 0)
        {
            mainManager = GameObject.Find("MainManager").GetComponent<MainManager>();
            animator.Play("Idle");
            gameOver = false;
            character = GetComponent<CharacterController>();
        }
        
        
    }
    // POLYMORPHISM
    public virtual void Punch()
    {
        if (mainManager.isGameActive)
            animator.SetTrigger("PunchTrigger");        
    }
    public virtual void Kick()
    {
        if (mainManager.isGameActive)
            animator.SetTrigger("KickTrigger");
    }
    public void Move(float value)
    {
        input.Set(0, 0, value);
        character.Move(input * Time.deltaTime * 2);

        if (value > 0) MoveFoward();
        else MoveBackward();

    }

    public virtual void MoveFoward()
    {
        SetDistance();
        if (isGround && distance < maxDist && mainManager.isGameActive)
        {
            animator.SetBool("Walk Backward", false);
            animator.SetBool("Walk Forward", true);           
        }
    }
    public virtual void MoveBackward()
    {
        SetDistance();
        if (isGround && distance < maxDist && mainManager.isGameActive)
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
    public void HitPlayer(float hit)
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
            mainManager.GameOver();
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
