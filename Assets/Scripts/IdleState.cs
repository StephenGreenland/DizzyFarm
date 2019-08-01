using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IdleState : StateBase
{
    private float timer;
    public override void Enter()
    {
        base.Enter();
        timer = 1f;
    }

    public override void Execute()
    {
        base.Execute();
        timer = timer -Time.deltaTime;

        if (timer < 0)
        {
            
            chickenScript.ChanageState(chickenScript.roamState);
        }
        
    }

    public override void Exit()
    {
        base.Exit();
    }
}
