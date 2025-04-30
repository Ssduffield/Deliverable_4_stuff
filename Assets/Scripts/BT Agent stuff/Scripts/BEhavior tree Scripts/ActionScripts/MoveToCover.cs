using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using XNode;

namespace BehaviorTree

{

	public class MoveToCover : BTActionNodeBase
	{

        protected override void OnStart()
        {
            
        }

        protected override void OnStop()
        {
            
        }

        protected override State OnUpdate()
        {

            RaycastHit hit;
            foreach (Transform spot in _owner.coverSpots)
            {
                if (Physics.Raycast(_owner.player.position, spot.position - _owner.player.position, out hit))
                {
                    if (hit.transform.tag == "Cover")
                    {
                        if (!_owner.GetNavAgent.pathPending)
                        {
                            _owner.GetNavAgent.SetDestination(spot.position);
                            return State.Success;
                        }
                    }

                }
            }

            return State.Failure;


        }
    }
}