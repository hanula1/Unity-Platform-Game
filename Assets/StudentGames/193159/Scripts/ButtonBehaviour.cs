using System.Collections;
using System.Collections.Generic;
using System.Xml.Linq;
using UnityEngine;
namespace _193159
{
    public class ButtonBehaviour : MonoBehaviour
    {
        public GameObject door;

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
            {
                door.SetActive(false);
            }
            else
            {
                door.SetActive(true);
            }
        }

        private void OnTriggerExit2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") || collision.gameObject.CompareTag("Box"))
            {
                door.SetActive(true);
            }
        }
    }
}
