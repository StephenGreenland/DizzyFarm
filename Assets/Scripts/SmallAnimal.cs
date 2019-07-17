using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class SmallAnimal : MonoBehaviour
{

    public enum States { roam, idle, run, notice };
    public States myState;

    float myRunDistance;
    float myNotoiceDistance;
    float roamWayPoint;
    

    float runspeed;
    
    

    public GameObject player;
    public GameObject player2;
    Vector3 waypoint;

    float timer;


    // Use this for initialization
    void Start()
    {
        

        timer = 1f;
        myState = States.idle;

        myNotoiceDistance = 8f;

        myRunDistance = 6f;

        roamWayPoint = .8f;

    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(player.transform.position, transform.position) < myRunDistance || Vector3.Distance(player2.transform.position, transform.position) < myRunDistance)
        {
            myState = States.run;
        }
        
      

        switch (myState)
        {

            case States.idle:
                Idle();

                break;

            case States.roam:
                Roam();

                break;

            case States.run:
                Run();

                break;

            case States.notice:
                Notice();

                break;

        }
    }

    void Idle()
    {


        timer -= Time.deltaTime;
        if (timer < 0)
        {
            
            myState = States.roam;
            timer = 1f;
            waypoint = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y, transform.position.z + (Random.Range(-2, 2)));

        }


    }
    void Roam()
    {


        transform.position = Vector3.MoveTowards(transform.position, waypoint, 2 * Time.deltaTime);

        transform.LookAt(waypoint);


        if (Vector3.Distance(waypoint, transform.position) < roamWayPoint)
        {
            myState = States.idle;


        }


    }
    void Run()
    {

        Vector3 runDirection = Vector3.zero;

        

        if (Vector3.Distance(player.transform.position, transform.position) < myRunDistance)
        {
            runDirection = player.transform.position;
        }
        else if (Vector3.Distance(player2.transform.position, transform.position) < myRunDistance)
        {
            runDirection = player2.transform.position;
        }
        else if (Vector3.Distance(player.transform.position, transform.position) < myRunDistance && Vector3.Distance(player2.transform.position, transform.position) < myRunDistance)
        {
            runDirection = new Vector3((player.transform.position.x + player2.transform.position.x) * 0.5f, 0, (player.transform.position.z + player2.transform.position.z) * 0.5f);
        }

        HowFast();

        // this.gameObject.GetComponent<NavMeshAgent>().SetDestination(runDirection);
        
        Vector3 nextStepp = Vector3.MoveTowards(transform.position, runDirection, runspeed*-1 * Time.deltaTime);

        transform.LookAt(nextStepp);

        transform.position = nextStepp;

        


        if (Vector3.Distance(player.transform.position, transform.position) > myRunDistance)
        {
            myState = States.notice;


        }

    }

    private void OnDrawGizmos()
    {
        Vector3 runDirection = new Vector3((player.transform.position.x + player2.transform.position.x) * 0.5f, 0, (player.transform.position.z + player2.transform.position.z) * 0.5f);
        Gizmos.DrawCube(runDirection, Vector3.one);
    }

    void Notice()
    {

        transform.LookAt(player.transform);

        if (Vector3.Distance(player.transform.position, transform.position) > myNotoiceDistance)
        {
            myState = States.idle;


        }
    }

    void HowFast()
    {
        runspeed = 10f - Vector3.Distance(transform.position, player.transform.position) + Vector3.Distance(transform.position, player.transform.position);
    }

    public void Home()
    {



    }

}
