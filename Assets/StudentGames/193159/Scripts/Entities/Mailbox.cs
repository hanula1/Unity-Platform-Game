using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _193159
{
    public class Mailbox : MonoBehaviour
    {
        [SerializeField] private GameObject tooltipCanvas;
        [SerializeField] private Sprite openMailboxSprite;
        [SerializeField] private SpriteRenderer spriteRenderer;
        [SerializeField] private ParticleSystem collidedParticleSystem;

        private bool isMailboxOpen = false;

        // to make interaction with 'E' key more reliable
        private bool isPlayerInTrigger = false;

        private void Update()
        {
            if (isPlayerInTrigger && !isMailboxOpen)
            {
                tooltipCanvas.SetActive(true);

                if (Input.GetKey(KeyCode.E))
                {
                    spriteRenderer.sprite = openMailboxSprite;
                    isMailboxOpen = true;
                    GameManager.Get().AddKeys();
                    AudioManager.Get().PlaySound(SoundType.KEY);
                    FireParticles();
                }
            }
            else
            {
                tooltipCanvas.SetActive(false);
            }
        }

        public void OnTriggerExit2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                isPlayerInTrigger = false;
            }
        }

        public void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.CompareTag("Player"))
            {
                isPlayerInTrigger = true;
            }
        }

        void FireParticles()
        {
            var emission = collidedParticleSystem.emission;
            emission.enabled = true;
            collidedParticleSystem.Play();
        }
    }

}
