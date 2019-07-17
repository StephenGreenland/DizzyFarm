using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float defaultFreq = 20.0f;
    public float frequency = 20.0f;  // Speed of sine movement
    public float magnitude = 0.5f;   // Size of sine movement
    CharacterController characterController;

    public float speed = 6.0f;
    public float jumpSpeed = 8.0f;
    public float gravity = 20.0f;

    private Vector3 moveDirection = Vector3.zero;

    private float freqTimer;
    private float freqCurTime;
    private float freqMaxTime;

    private float curFreq;
    private float newFreq;
    private float alpha;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    void Update()
    {
        if (characterController.isGrounded)
        {
            

            moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            if (moveDirection.x > 0.1f)
            {
                moveDirection.z += Mathf.Sin(Time.time * frequency) * magnitude;
            }
            else if( moveDirection.x < -0.1f)
            {
                moveDirection.z -= Mathf.Sin(Time.time * frequency) * magnitude;
            }
            if (moveDirection.z > 0.1f)
            {
                moveDirection.x += Mathf.Sin(Time.time * frequency) * magnitude;
            }
            else if (moveDirection.z < -0.1f)
            {
                moveDirection.x -= Mathf.Sin(Time.time * frequency) * magnitude;
            }

            if(moveDirection.x < 0.1f && moveDirection.x > -0.1f &&
                moveDirection.z < 0.1f && moveDirection.z > -0.1f)
            {
                curFreq = 0;
            }
            else
            {
                Frequency();
            }



            moveDirection *= speed;

            if (Input.GetButton("Jump"))
            {
                moveDirection.y = jumpSpeed;
            }
        }

        // Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
        // when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
        // as an acceleration (ms^-2)
        moveDirection.y -= gravity * Time.deltaTime;

        Debug.Log(moveDirection);
        // Move the controller
        characterController.Move(moveDirection * Time.deltaTime);
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
            if(freqCurTime >= freqMaxTime)
            {
                freqCurTime = 0;
                freqMaxTime = Random.Range(0.5f, 1.5f);
            }
            else
            {
                freqCurTime += Time.deltaTime;
            }
            alpha = freqCurTime/freqMaxTime;
        }

        frequency = Mathf.Lerp(curFreq, newFreq, alpha);
    }
    
}
