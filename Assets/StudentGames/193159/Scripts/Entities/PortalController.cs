using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace _193159
{
    public class PortalController : MonoBehaviour
    {
        [SerializeField] private GameObject portal1;
        [SerializeField] private GameObject portal2;
        [SerializeField] private float teleportOffset;

        public void Teleport(Portal enteredPortal, GameObject enteringEntity)
        {
            if(enteredPortal.gameObject == portal1)
            {
                TeleportToSide(portal2, enteringEntity);
            }
            else 
            {
                TeleportToSide(portal1, enteringEntity);
            }
        }

        private void TeleportToSide(GameObject destinationPortal, GameObject enteringEntity)
        {
            float offset = (destinationPortal.GetComponent<Portal>().entranceFrom == Direction.RIGHT ? -1 : 1 ) * teleportOffset;
            enteringEntity.transform.position = destinationPortal.transform.position;
            enteringEntity.transform.position += new Vector3(offset, 0, 0);
        }

    }
}
