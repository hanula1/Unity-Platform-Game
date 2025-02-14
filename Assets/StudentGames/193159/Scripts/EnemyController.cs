using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SocialPlatforms.Impl;
namespace _193159
{
    [RequireComponent(typeof(BoxCollider2D))]
    [RequireComponent(typeof(MovementController))]
    public class EnemyController : MonoBehaviour
    {
        private Animator animator;
        void Awake()
        {
            animator = GetComponent<Animator>();
        }

        IEnumerator KillOnAnimationEnd()
        {
            yield return new WaitForSeconds(1);
            gameObject.SetActive(false);
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Player"))
            {
                float tHead = GetObjectHeadLevel(this.gameObject);
                float tpp = GetPixelPecentageOfObjectHeight(this.gameObject, 0.45f);
                float pFoot = GetObjectFootLevel(other.gameObject);
                if (tHead - tpp < pFoot)
                {
                    Collider2D[] colliders = this.gameObject.GetComponents<Collider2D>();
                    foreach(Collider2D collider in colliders)
                    {
                        collider.enabled = false;
                    }
                    this.gameObject.GetComponent<MovementController>().enabled = false;
                    animator.SetBool("isDead", true);
                    StartCoroutine(KillOnAnimationEnd());
                    AudioManager.Get().PlaySound(SoundType.ENEMY_SUCCESS);
                    GameManager.Get().KilledEnemy();
                }
                else
                {
                    GameManager.Get().player.health.TakeDamage();
                    AudioManager.Get().PlaySound(SoundType.ENEMY_DEFEAT);
                    GameManager.Get().player.respawnController.Respawn();
                }
            }
        }

        float GetObjectHeadLevel(GameObject gameObject)
        {
            BoxCollider2D bx = gameObject.GetComponent<BoxCollider2D>();
            return bx.transform.position.y + bx.size.y / 2;
        }
        float GetObjectFootLevel(GameObject gameObject)
        {
            BoxCollider2D bx = gameObject.GetComponent<BoxCollider2D>();
            return bx.transform.position.y - bx.size.y / 2;
        }

        float GetPixelPecentageOfObjectHeight(GameObject gameObject, float percentage)
        {
            BoxCollider2D bx = gameObject.GetComponent<BoxCollider2D>();
            return bx.size.y * percentage;
        }
    }
}