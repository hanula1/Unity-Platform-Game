using UnityEngine;

namespace _193159
{
    public class Heart : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                Health health = other.gameObject.GetComponent<Health>();
                if (health.lives == health.maxHealth)
                {
                    return;
                }
                health.Heal();
                AudioManager.Get().PlaySound(SoundType.HEART);
                this.gameObject.SetActive(false);
            }
        }
    }
}
