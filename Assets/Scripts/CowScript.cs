using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CowScript : MonoBehaviour
{

    private Rigidbody rb;

    public GameObject player;
    public GameObject player2;
    private GameObject target;
    private GameObject fence;
    public PhysicMaterial fenceMat;

    public AudioClip[] Moos;
    private AudioSource aS;

    private float fenceSpeed;

    public float speed;

    

    float timer;


    // Start is called before the first frame update
    void Start()
    {
        aS = this.gameObject.GetComponent<AudioSource>();
        fenceSpeed = 100f;
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
        aS.clip = Moos[Random.RandomRange(0,Moos.Length)];
        aS.Play();
     }

    public void Moove2()
    {
        target = player2;
        timer = 4f;
        aS.clip = Moos[Random.RandomRange(0, Moos.Length)];
        aS.Play();
    }


     void OnTriggerEnter(Collider col)
     {

         if (col.gameObject.tag == "Player")
         {
             
             col.gameObject.GetComponent<FarmerScript>().GotHit();
             timer = 0f;
         }
         if (col.gameObject.tag == "Player2")
         {
             
             col.gameObject.GetComponent<FarmerScript2>().GotHit();
             timer = 0f;
         }

         if (col.gameObject.tag == "Fence")
         {
             
             col.GetComponent<Rigidbody>().isKinematic = false;
             col.GetComponent<BoxCollider>().material = fenceMat;
             
             rb.AddRelativeForce(0, fenceSpeed, 0);
             //Destroy(col.gameObject);

         }
       
       
    }

     
}
