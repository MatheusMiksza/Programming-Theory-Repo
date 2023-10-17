using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : FigtherUnit
{
    private float fixX = 0;
    private void Start()
    {
        fighter = this.gameObject;
        playerRb = this.gameObject.GetComponent<Rigidbody>();
        playerCollider = this.gameObject.GetComponent<CapsuleCollider>();
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
            if (collision.gameObject.CompareTag("Kick"))
            {
               
                Hit(-15);
            }
        }
        if (collision.transform.root.name == "Grid")
            IsGround(true); 
    }

    

}
