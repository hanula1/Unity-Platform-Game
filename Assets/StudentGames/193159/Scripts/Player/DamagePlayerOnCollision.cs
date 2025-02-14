
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace _193159
{

    public class DamagePlayerOnCollision : MonoBehaviour
    {
        void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Player"))
            {
                if (isPlayerAboveEnemy(other))
                {
                    GameManager.Get().AddPoints(50);
                    AudioManager.Get().PlaySound(SoundType.ENEMY_DEFEAT);
                    GameManager.Get().KilledEnemy();
                }
                else
                {
                    PlayerController player = other.gameObject.GetComponent<PlayerController>();
                    player.health.TakeDamage();
                    AudioManager.Get().PlaySound(SoundType.ENEMY_SUCCESS);
                    player.respawnController.Respawn();
                }
            }
        }

        private bool isPlayerAboveEnemy(Collision2D other)
        {
            return other.gameObject.transform.position.y > this.gameObject.transform.position.y;
        }
    }

}
