using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerScript : MonoBehaviour
{
    public float speed;
    Rigidbody rb;
    Vector3 moveDirection;
    Vector3 lookIn;
    
    public bool isKnockedOver;
    private float timer;

    public float defaultFreq = 20.0f;
    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement

    private float freqTimer;
    private float freqCurTime;
    private float freqMaxTime;

    private float curFreq;
    private float newFreq;
    private float alpha;



    // Start is called before the first frame update
    void Awake()
    {
        rb = GetComponent<Rigidbody>();

    }

    void FixedUpdate()
    {
        if (isKnockedOver)
        {
            if (timer < 0)
            {
                isKnockedOver = false;
                gameObject.transform.rotation = new Quaternion(0,0,0,0);

                gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotation;
            }
            timer -= Time.deltaTime;
        }
        else
        {
            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0, Input.GetAxis("Vertical"));

            if (moveDirection != Vector3.zero)
            {
                transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(moveDirection), .15f);
            }


            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0)
            {
                rb.AddRelativeForce(0, 0, speed);
            }

            // checking if ifs moving and if it is it adds mathf.sin to it

            if (rb.velocity.z > 0.1f || rb.velocity.x > 0.1f || rb.velocity.z < -0.1f || rb.velocity.x < -0.1f)
            {
                rb.AddRelativeForce(0 + Mathf.Sin(Time.time * frequency) * magnitude, 0, 0);
            }

            if (rb.velocity.x < 0.1f && rb.velocity.x > -0.1f &&
                rb.velocity.z < 0.1f && rb.velocity.z > -0.1f)
            {
                curFreq = 0;
            }
            else
            {
                Frequency();
            }

            // clamping the velocity
            Vector2 v = new Vector2(rb.velocity.x, rb.velocity.z);
            v = Vector2.ClampMagnitude(v, 6f);
            rb.velocity = new Vector3(v.x, rb.velocity.y, v.y);
        }

    }
    void Frequency()
    {
        if (alpha >= 1)
        {
            alpha = 0;
            curFreq = newFreq;
            newFreq = Random.Range(1f, 2f);
        }
        else
        {
            if (freqCurTime >= freqMaxTime)
            {
                freqCurTime = 0;
                freqMaxTime = Random.Range(0.5f, 1.5f);
            }
            else
            {
                freqCurTime += Time.deltaTime;
            }
            alpha = freqCurTime / freqMaxTime;
        }

        frequency = Mathf.Lerp(curFreq, newFreq, alpha);
    }
    public void GotHit()
    {
        isKnockedOver = true;
        
        gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;

        timer = 3f;
        
    }
    void OnCollisionEnter(Collision col)
    {

        if (col.gameObject.tag == "Player2")
        {

            GotHit();
        }
    }
}
