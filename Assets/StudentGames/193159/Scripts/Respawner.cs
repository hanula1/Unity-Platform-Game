using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace _193159
{
    public class Respawner : MonoBehaviour
    {
        private PlayerRespawnController playerRespawnController;

        private void Start()
        {
            playerRespawnController = GameObject.FindGameObjectWithTag("Player").gameObject.GetComponent<PlayerRespawnController>();
        }

        private void Update()
        {

            GameObject bloom = transform.Find("bloom").gameObject;
            if (ReferenceEquals(this.gameObject, playerRespawnController.activeCheckpoint))
            {
                bloom.SetActive(true);
            }
            else
            {
                bloom.SetActive(false);
            }
        }

        private void OnTriggerEnter2D(Collider2D collision)
        {
            if (collision.gameObject.tag == "Player" && !ReferenceEquals(this.gameObject, playerRespawnController.activeCheckpoint))
            {
                Vector2 respawnPosition = new Vector2(transform.position.x, transform.position.y);
                respawnPosition.y += collision.bounds.size.y;
                playerRespawnController.lastCheckpoint = respawnPosition;
                playerRespawnController.activeCheckpoint = this.gameObject;
                AudioManager.Get().PlaySound(SoundType.CHECKPOINT);
                FireParticles();
            }

            void FireParticles()
            {
                var particles = GetComponentInChildren<ParticleSystem>();
                var emission = particles.emission;
                emission.enabled = true;
                particles.Play();
            }
        }
    }
}
