using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace _193159
{
    [RequireComponent(typeof(PlayerMovementController))]
    [RequireComponent(typeof(PlayerRespawnController))]
    [RequireComponent(typeof(Health))]
    public class PlayerController : MonoBehaviour
    {
        private PlayerMovementController movement;
        public PlayerRespawnController respawnController;
        public Health health;
        public Animator animator;

        void Awake()
        {
            animator = GetComponent<Animator>();
            movement = GetComponent<PlayerMovementController>();
            respawnController = GetComponent<PlayerRespawnController>();
            health = GetComponent<Health>();
            health.maxHealth = 3;
        }

        void Update()
        {
            if (GameManager.Get().state.currentGameState != GameState.IN_GAME)
            {
                return;
            }
            movement.UpdatePlayerPos();

            if (health.lives == 0)
            {
                Debug.Log("Game over!");
                GameManager.Get().RestartLevel();
            }

            animator.SetBool("isTouchingGround", movement.isTouchingGround());
            animator.SetBool("isWalking", movement.IsWalking());
            animator.SetBool("isFalling", movement.isFalling());
        }

        /* TO CLEAN UP */
        private void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag("Finish"))
            {
                if (GameManager.Get().GetKeysFound() == InGameMenu.Get().keysTab.Length)
                {
                    GameManager.Get().AddPoints(100 * health.lives);
                    AudioManager.Get().PlaySound(SoundType.FINISH);
                    GameManager.Get().SaveScore();
                    StateManager.Get().SetState(GameState.LEVEL_COMPLETED);
                }
            }
            else if (other.CompareTag("FallLevel"))
            {
                health.TakeDamage();
                AudioManager.Get().PlaySound(SoundType.FALL);
                respawnController.Respawn();
            }

        }

        private void OnCollisionEnter2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("MovingPlatform"))
            {
                transform.SetParent(collision.gameObject.transform);
            }
        }

        private void OnCollisionExit2D(Collision2D collision)
        {
            if (collision.gameObject.CompareTag("MovingPlatform"))
            {
                transform.SetParent(null);
            }
        }
    }
}
