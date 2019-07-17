using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMOD.Studio;
using FMODUnity;


public class ChickenScript : MonoBehaviour
{
    private List<GameObject> spookypeople;
    
    public GameObject player;

    private NavMeshAgent _agent;

    private float runDistance = 4f;

    private Transform t;

    [EventRef]
    public string footstepEvent;
    

    // Start is called before the first frame update
    void Start()
    {

        RuntimeManager.PlayOneShotAttached(footstepEvent, gameObject);
        

       t = transform; 
        
        spookypeople = new List<GameObject>();
        
        _agent = gameObject.GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {

        float distance = Vector3.Distance(t.position,
            player.gameObject.transform.position);

        if (distance < runDistance)
        {
            Vector3 dirToPlayer = transform.position - player.transform.position;

            Vector3 tempPos = transform.position + dirToPlayer;

            _agent.SetDestination(tempPos);



        }

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Threats>() != null)
        {

            spookypeople.Add(other.gameObject);

            print(spookypeople[0]);
            
        }    
        
        
        
        
    
    }
}
