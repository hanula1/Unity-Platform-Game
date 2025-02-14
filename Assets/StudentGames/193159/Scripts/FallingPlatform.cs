using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
namespace _193159
{
    public class FallingPlatform : MonoBehaviour
    {
        // Start is called before the first frame update
        [SerializeField] private float fallDelay = 1f;
        [SerializeField] private float respawnTime = 3f;
        private Rigidbody2D rb;
        bool isFallable = true;
        bool isFalling = false;

        Vector2 defaultPosition;
        void Start()
        {
            defaultPosition = transform.position;
            rb = GetComponent<Rigidbody2D>();
        }

        private void Reset()
        {
            rb.bodyType = RigidbodyType2D.Static;
            transform.position = defaultPosition;
        }

        private void OnTriggerStay2D(Collider2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && isFallable && !isFalling)
            {
                StartCoroutine(Fall());
            }
        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("Player") && collision.enabled)
            {
                isFallable = true;
            }
            else
            {
                isFallable = false;
            }
        }


        private IEnumerator Fall()
        {
            isFalling = true;
            yield return new WaitForSeconds(fallDelay);
            rb.bodyType = RigidbodyType2D.Dynamic;
            yield return new WaitForSeconds(respawnTime);
            isFalling = false;
            Reset();
        }
    }
}
