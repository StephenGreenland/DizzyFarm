using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{

    Rigidbody rb;

    public GameObject player;
    public GameObject player2;

    private bool p;
    private bool o;

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
        if (p)
        {
            Moove();
        }

        if (o)
        {
            Moove2();
        }
        
    }

     public void Moove()
     {
         timer = timer -Time.deltaTime;
            
         if (timer > 0)
         {
             transform.LookAt(player.GetComponent<Transform>().position);

             rb.AddRelativeForce(0, 0, speed);
         }

     }

     public void Moove2()
     {
         timer = timer -Time.deltaTime;
        
         if (timer > 0)
         {
             transform.LookAt(player2.GetComponent<Transform>().position);

             rb.AddRelativeForce(0, 0, speed);
         }
         
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
             Destroy(col.gameObject);
             
         }
       
    }

     
}
