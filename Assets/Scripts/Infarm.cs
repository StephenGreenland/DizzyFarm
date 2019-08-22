using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Infarm : MonoBehaviour
{
    private bool isOnFarm;
    private bool isOnFarm2;
    private float timer;
    private float timer2;
    public GameObject player;
    public GameObject player2;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;
        isOnFarm = true;
        timer2 = 3f;
        isOnFarm2 = true;
    }

    // Update is called once per frame
    void Update()
    {
     
        if (isOnFarm == false)
        {
            timer = timer -Time.deltaTime;

        }
        if(timer < 0)
        {
            player.gameObject.transform.position = new Vector3(0, 2, 0);
            timer = 3f;
            isOnFarm = true;

        }
        if (isOnFarm2 == false)
        {
            timer2 = timer2 -Time.deltaTime;

        }
        if (timer2 < 0)
        {
            player2.gameObject.transform.position = new Vector3(0, 2, 0);
            timer2 = 3f;
            isOnFarm2 = true;

        }
    }

    private void OnTriggerEnter(Collider other)
    {
        
        if(other.gameObject.tag == "Player")
        {

            isOnFarm = false;

        }
        if (other.gameObject.tag == "Player2")
        {

            isOnFarm2 = false;

        }

    }

}
