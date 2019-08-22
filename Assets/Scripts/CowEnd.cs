using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowEnd : MonoBehaviour
{
    public float speed;
    private Rigidbody rb;
    public GameObject sheep;
    

    // Start is called before the first frame update
    void Start()
    {
        rb = this.gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.LookAt(sheep.GetComponent<Transform>().position);
        rb.AddRelativeForce(0, 0, speed);
    }
}
