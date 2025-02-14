using UnityEngine;

namespace _193159
{
    public class Key : MonoBehaviour
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                GameManager.Get().AddKeys(other.gameObject.GetComponent<SpriteRenderer>().color);
                AudioManager.Get().PlaySound(SoundType.KEY);
                gameObject.SetActive(false);
            }
        }
    }
}
