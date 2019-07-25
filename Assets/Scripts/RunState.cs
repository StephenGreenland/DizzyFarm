using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class RunState : StateBase
{
    private float runDistance = 4f;

    public override void Enter()
    {
        base.Enter();
    }

    public override void Execute()
    {
        base.Execute();

        Vector3 dirToPlayer = transform.position - chickenScript.getRunDirection();
        dirToPlayer.Normalize();

        Vector3 tempPos = transform.position + dirToPlayer * chickenScript.runSpeed;

        chickenScript._agent.SetDestination(tempPos + new Vector3(chickenScript.randomrange+Random.Range(-2f,2f), 0 , -chickenScript.randomrange+Random.Range(-2f,2f))); 


        chickenScript.ChanageState(GetComponent<RunState>());
    }

    public override void Exit()
    {
        base.Exit();
    }
}