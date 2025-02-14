using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace _193159
{
    public class Portal : MonoBehaviour
    {
        [SerializeField] public Direction entranceFrom;

        void Start()
        {
        
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                this.transform.parent.gameObject.GetComponent<PortalController>().Teleport(this, other.gameObject);
            }
        }
    }
}
