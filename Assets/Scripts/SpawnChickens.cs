using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnChickens : MonoBehaviour
{
    private float timer;
    public GameObject chicken;
    private Vector3 myPosition;
    
   
    void Start()
    {
        myPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
        
        timer = timer - Time.deltaTime;

        if (timer < 0)
        {
            SpawnChicken();
        }
        
    }

    private void SpawnChicken()
    {
        Instantiate(chicken, new Vector3(myPosition.x+Random.Range(-20f,20f),myPosition.y,myPosition.z+Random.Range(-20f,20f)),transform.rotation);
        timer = 10f;
    }
    
    
    
    
}
