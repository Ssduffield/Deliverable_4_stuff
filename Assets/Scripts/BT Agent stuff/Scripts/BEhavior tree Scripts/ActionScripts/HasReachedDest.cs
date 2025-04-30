using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree
{

    public class HasReachedDest : BTActionNodeBase
    {
        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {
            return _owner.HasReachedDest ? State.Success : State.Failure;
        }
    }
}