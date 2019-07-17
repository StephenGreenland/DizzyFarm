using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowScript : MonoBehaviour
{

    Rigidbody rb;

    public GameObject player;

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
        if (timer > 0)
        {
            timer = timer -Time.deltaTime;

            transform.LookAt(player.GetComponent<Transform>().position);

            // rb.AddRelativeForce(new Vector3(player.transform.position.x,this.gameObject.GetComponent<Transform>().position.y, player.transform.position.z) * speed);

            rb.AddRelativeForce(0, 0, speed);

            
        }

        
    }

     public void Moove()
     {
        Debug.Log("slap");

        // playsound

        timer = 4f;

     }

}
