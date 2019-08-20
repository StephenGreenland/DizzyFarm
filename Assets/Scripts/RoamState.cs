using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : StateBase
{

    private float timer;
    private float roamWayPoint = .8f;
    public override void Enter()
    {
        timer = 3f;
        base.Enter();
        chickenScript.wayPoint = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y, transform.position.z + (Random.Range(-2, 2)));
        chickenScript._agent.SetDestination(chickenScript.wayPoint);
        ani.SetBool("isIdle", false);
    }

    public override void Execute()
    {
        
        base.Execute();
        timer -= Time.deltaTime;
        if (Vector3.Distance(chickenScript.wayPoint, transform.position) < roamWayPoint)
        {
           chickenScript.ChanageState(chickenScript.idleState);
        }
        if(timer > 0)
        {
            chickenScript.ChanageState(chickenScript.idleState);

        }
    }

    public override void Exit()
    {
        base.Exit();
        
    }
    
}
