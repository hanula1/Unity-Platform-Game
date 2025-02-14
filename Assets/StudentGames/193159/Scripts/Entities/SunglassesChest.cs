using UnityEngine;

namespace _193159
{

    public class SunglassesChest : MonoBehaviour
    {
        [SerializeField] private ParticleSystem collidedParticleSystem;
        [SerializeField] private GameObject eyes;
        bool isCollected = false;
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player") && !isCollected)
            {
                GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>().animator.SetBool("haveOksy", true);
                isCollected = true;
                eyes.SetActive(false);
                AudioManager.Get().PlaySound(SoundType.SUNGLASSES);
                FireParticles();
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
