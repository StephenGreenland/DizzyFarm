﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CowScript : MonoBehaviour
{

    private Rigidbody rb;

    public GameObject player;
    public GameObject player2;
    private GameObject target;




    public float speed;

    float timer;


    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        timer = timer - Time.deltaTime;

        if (timer > 0)
        {
            transform.LookAt(target.GetComponent<Transform>().position);

            rb.AddRelativeForce(0, 0, speed);
        }


    }

     public void Moove()
     {
        target = player;
        timer = 4f;
     }

    public void Moove2()
    {
        target = player2;
        timer = 4f;

    }


     void OnTriggerEnter(Collider col)
     {

         if (col.gameObject.tag == "Player")
         {
             
             // knock the player over
             timer = 0f;
         }

         if (col.gameObject.tag == "Fence")
         {

            //col.GetComponent<Rigibody>().Constraints = RigidbodyConstraints.FreezePosition;

            //Destroy(col.gameObject);
             
         }
       
       
    }

     
}
