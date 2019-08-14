using System.Collections;
using System.Collections.Generic;
using UnityEngine;



    public class StateBase : MonoBehaviour
    {
        public ChickenScript chickenScript;
        public Animator ani;

    public virtual void Enter()
        {
            

        }

        public virtual void  Execute()
        {
         
        }

        public virtual void  Exit()
        {

        }
    }
