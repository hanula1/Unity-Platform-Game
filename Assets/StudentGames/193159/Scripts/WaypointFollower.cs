using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _193159
{
    public class WaypointFollower : MonoBehaviour
    {

        enum LoopType
        {
            CYCLIC,
            PENDULUM
        }

        [SerializeField] private GameObject[] waypoints;
        private float speed = 1.0f;
        [SerializeField] private float SLOW_SPEED;
        [SerializeField] private float BASE_SPEED;
        [SerializeField] private float SLOWED_SPEED_DISTANCE;
        [SerializeField] private LoopType loopType = LoopType.CYCLIC;

        private int currentWaypoint = 0;
        void Update()
        {
            float distanceToNextWaypoint = Vector2.Distance(this.transform.position, waypoints[currentWaypoint].transform.position);
            if (distanceToNextWaypoint < 0.1f)
            {
                currentWaypoint = CalculateNextWaypointNumber();
            }
            speed = distanceToNextWaypoint < SLOWED_SPEED_DISTANCE ? SLOW_SPEED : BASE_SPEED;
            this.transform.position = Vector2.MoveTowards(this.transform.position, waypoints[currentWaypoint].transform.position, (speed * Time.deltaTime));
        }

        private int CalculateNextWaypointNumber()
        {
            int nextWaipointNumber = 0;
            switch (loopType)
            {
                case LoopType.CYCLIC:
                    nextWaipointNumber = (currentWaypoint + 1) % waypoints.Length;
                    break;
                case LoopType.PENDULUM:
                    // TODO: implement
                    break;
            }
            return nextWaipointNumber;
        }

    }
}
