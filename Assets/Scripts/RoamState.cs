using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoamState : StateBase
{
    private float roamWayPoint = .8f;
    public override void Enter()
    {
        base.Enter();
        chickenScript.wayPoint = new Vector3(transform.position.x + Random.Range(-2, 2), transform.position.y, transform.position.z + (Random.Range(-2, 2)));
        chickenScript._agent.SetDestination(chickenScript.wayPoint);
    }

    public override void Execute()
    {
        base.Execute();
        if (Vector3.Distance(chickenScript.wayPoint, transform.position) < roamWayPoint)
        {
           chickenScript.ChanageState(chickenScript.idleState);
        }
        
    }

    public override void Exit()
    {
        base.Exit();
        
    }
    
}
