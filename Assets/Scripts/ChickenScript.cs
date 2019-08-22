using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMODUnity;


public class ChickenScript : MonoBehaviour
{
    
    #region Variables
    
    public List<GameObject> spookypeople;
   
    public NavMeshAgent _agent;

    public float runDistance = 4f;

    private Vector3 averageDis;

    private Transform t;

    [EventRef]
    public string footstepEvent;

    public float runSpeed;

    public StateBase currentstate;
    public StateBase runState;
    public StateBase idleState;
    public StateBase roamState;

    
    public Vector3 wayPoint;
    public float randomrange;

    
  
    #endregion
    



    void Start()
    {
        
        runState = GetComponent<RunState>();
        idleState = GetComponent<IdleState>();
        roamState = GetComponent<RoamState>();
        
        ChanageState(GetComponent<IdleState>());
        
        runSpeed = 5f;
        
       // RuntimeManager.PlayOneShotAttached(footstepEvent, gameObject);
        
        t = transform; 
        
        spookypeople = new List<GameObject>();
        
        
        _agent = gameObject.GetComponent<NavMeshAgent>();
        
        
    }
    
    void Update()
    {

        
        
        if (spookypeople.Count != 0)
        {
            ChanageState(runState);
            
        }
        currentstate.Execute();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<Threats>() != null)
        {
            spookypeople.Add(other.gameObject);

            
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Threats>() != null)
        {
            
            
            spookypeople.Remove(other.gameObject);
        }
    }

     public Vector3 getRunDirection()
    {
        averageDis = Vector3.zero;
        
        for (int i = 0; i < spookypeople.Count; i++)
        {
            averageDis = averageDis + spookypeople[i].transform.position;
        }

        averageDis = averageDis / spookypeople.Count;
        
        
        
        return averageDis;
    }

     public void ChanageState(StateBase newstate)
    {
        currentstate.Exit();
        newstate.Enter();
        currentstate = newstate;
    }
    
    
}
