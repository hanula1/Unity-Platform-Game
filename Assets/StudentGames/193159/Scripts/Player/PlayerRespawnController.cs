using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;
namespace _193159
{
    /* CHECKPOINTS IN FUTURE? */
    public class PlayerRespawnController : MonoBehaviour
    {
        private Vector2 startPosition;
        [NonSerialized] public Vector2 lastCheckpoint;
        [NonSerialized] public GameObject activeCheckpoint;
        private PlayerMovementController movement;

        void Awake()
        {
            startPosition = this.transform.position;
            lastCheckpoint = startPosition;
            movement = GetComponent<PlayerMovementController>();
        }

        public void Respawn()
        {
            this.transform.position = lastCheckpoint;
            movement.Stop();
        }

        public void RespawnAtPosition(Vector3 position)
        {
            this.transform.position = position;
        }
    }
}
