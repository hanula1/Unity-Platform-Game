using UnityEngine;

namespace _193159
{
    public class Bonus : MonoBehaviour
    {
        [SerializeField] private ParticleSystem collidedParticleSystem;
        [SerializeField] private SpriteRenderer spriteRenderer;
        bool isCollected = false;

        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && !isCollected)
            {
                GameManager.Get().AddPoints(10);
                AudioManager.Get().PlaySound(SoundType.BONUS);
                isCollected = true;
                FireParticles();
            }
        }

        void FireParticles()
        {
            var emission = collidedParticleSystem.emission;
            emission.enabled = true;
            collidedParticleSystem.Play();
            spriteRenderer.enabled = false;
            Destroy(gameObject, collidedParticleSystem.main.duration);
        }
    }
}
