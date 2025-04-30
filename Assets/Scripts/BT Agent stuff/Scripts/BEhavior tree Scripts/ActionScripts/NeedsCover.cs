using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{

    public class NeedsCover : BTActionNodeBase
    {
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            return _owner.GetComponent<EnemyController>().enemyHealth < 25 ? State.Success : State.Failure;
        }
    }
}