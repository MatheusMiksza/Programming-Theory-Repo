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
    }

    private void Update()
    {
        if (transform.position.x != fixX) FixaPos();
    }

    private void FixaPos()
    {
        transform.position = new Vector3(fixX, transform.position.y, transform.position.z);
    }


    private void OnCollisionEnter(Collision collision)
    {
        if(collision.transform.root.name != gameObject.transform.root.name)
        {
           
            if (collision.gameObject.CompareTag("Kick"))
            {

            }
        }
       
    }

}
