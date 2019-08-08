using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CowButtScript : MonoBehaviour
{
    public float slapspeed;

    public GameObject cow;

    // Start is called before the first frame update
    void Start()
    {
        

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "hand")
        {
            
            cow.GetComponent<CowScript>().Moove();
        }
        
        if (other.gameObject.tag == "hand2")
        {
            
            cow.GetComponent<CowScript>().Moove2();
        }
    }
    
    
}
