using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using FMODUnity;


public class ChickenScript : MonoBehaviour
{
    
    #region Variables
    
    private List<GameObject> spookypeople;
   
    public NavMeshAgent _agent;

    public float runDistance = 4f;

    private Vector3 averageDis;

    private Transform t;

    [EventRef]
    public string footstepEvent;

    public float runSpeed;

    public StateBase currentstate;

    public float randomrange;
    #endregion
    



    void Start()
    {
        runSpeed = 5f;
        
        RuntimeManager.PlayOneShotAttached(footstepEvent, gameObject);
        
        t = transform; 
        
        spookypeople = new List<GameObject>();
        
        _agent = gameObject.GetComponent<NavMeshAgent>();
        
        currentstate = new RunState();
    }
    
    void Update()
    {
        if (spookypeople.Count != 0)
        {
            currentstate.Execute();
            //Run();
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

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.GetComponent<Threats>() != null)
        {
            print(spookypeople[0]);
            
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
        
        Debug.DrawLine(averageDis,averageDis+Vector3.up*10f, Color.red);
        
        return averageDis;
    }

   /* void Run()
    {
        Vector3 dirToPlayer = transform.position - getRunDirection();
        dirToPlayer.Normalize();

        Vector3 tempPos = transform.position + dirToPlayer * runSpeed;

        _agent.SetDestination(tempPos + new Vector3(randomrange+Random.Range(-2f,2f), 0 , -randomrange+Random.Range(-2f,2f))); 
        
    } */

    public void ChanageState(StateBase newstate)
    {
        currentstate.Exit();
        newstate.Enter();
        currentstate = newstate;
    }
    
    
 
}
