using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AICore;

namespace BehaviorTree
{
    public class BTAgent : AIAgentBase
    {
        [SerializeField] private BehaviorTreeGraph btGraph;
        [SerializeField] private Transform[] _waypoints;
        [SerializeField] public Transform player;
        [SerializeField] public List<Transform> coverSpots = new List<Transform>();

        private Dictionary<string, object> _blackboard;

        public Dictionary<string, object> GetBlackboard { get { return _blackboard; } }

        protected override void Start()
        {
            base.Start();

            _blackboard = new Dictionary<string, object>();
            _blackboard.Add("Waypoints", _waypoints);
            _blackboard.Add("WaypointIndex", 0);

            if (btGraph != null)
            {
                btGraph = btGraph.Copy() as BehaviorTreeGraph;
                btGraph.InitBehaviortree(this);
            }
        }

        protected override void FixedUpdate()
        {
            AssessTargets();

            if (btGraph != null && btGraph.rootNode != null)
            {
                btGraph.Update();
            }


            base.FixedUpdate();
        }
    }
}