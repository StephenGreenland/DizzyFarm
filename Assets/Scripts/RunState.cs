using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunState : StateBase
{
    private float runDistance = 4f;

    public override void Enter()
    {
        base.Enter();
        ani.SetBool("isIdle", false);
    }

    public override void Execute()
    {
        base.Execute();
        

        Vector3 dirToPlayer = transform.position - chickenScript.getRunDirection();
        dirToPlayer.Normalize();

        Vector3 tempPos = transform.position + dirToPlayer * chickenScript.runSpeed;

        chickenScript._agent.SetDestination(tempPos);
        if (chickenScript.spookypeople.Count == 0)
        {
            chickenScript.ChanageState(chickenScript.idleState);
            
        }
        
        
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}