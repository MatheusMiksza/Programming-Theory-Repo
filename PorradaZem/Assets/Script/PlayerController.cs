using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FigtherUnit
{
    private float fixX = 0;
    [SerializeField]
    private float punchHit;
    [SerializeField]
    private float kickHit;

    private string enemy;

   
    private void Start()
    {
        enemy = this.gameObject.transform.root.name == "Player01"? "Player01": "Player02";
        fighter = this.gameObject;
        playerRb = this.gameObject.GetComponent<Rigidbody>();
        playerCollider = this.gameObject.GetComponent<CapsuleCollider>();
        player02Controller = GameObject.Find(enemy).GetComponentInChildren<PlayerController>();
    }

    private void Update()
    {
        if (transform.position.x != fixX) FixaPos(new Vector3(fixX, transform.position.y, transform.position.z));
        if (transform.position.x < fixX) FixaPos(new Vector3(fixX, fixX, transform.position.z));
    }

    private void FixaPos(Vector3 pos)
    {
        transform.position = pos;
    }


    private void OnCollisionEnter(Collision collision)
    {
        
        if (collision.transform.root.name != gameObject.transform.root.name)
        {            
            if (collision.gameObject.CompareTag("Kick") || collision.gameObject.CompareTag("Punch"))
            {
                HitParticles(collision);  
                Hit(collision.gameObject.CompareTag("Kick")? player02Controller.kickHit: player02Controller.punchHit);
            }
        }
        if (collision.transform.root.name == "Grid")
            IsGround(true); 
    }

    

}
