using System;
using System.Linq;
using UnityEngine;
namespace _193159
{
using static Direction;

    class PlayerMovementController : MonoBehaviour
    {
        [Header("Movement parameters")]
        [Range(0.01f, 20.0f)] [SerializeField] private float moveSpeed;
        [Range(0.01f, 20.0f)] [SerializeField] private float jumpForce;
        [SerializeField] public LayerMask groundLayer;

        [SerializeField] public Sprite newSprite;

        private bool isWalking = false;
        private Direction facingDirection = RIGHT;
        private bool canJumpSecondTime = false;

        private Transform playerTransform;
        private Rigidbody2D rigidBody;
        private BoxCollider2D boxCollider;

        private float rayNearGroundLength = 1.2f;
        private float rayTouchingGroundLength;

        public void Awake()
        {
            playerTransform = this.transform;
            boxCollider = GetComponent<BoxCollider2D>();
            rigidBody = GetComponent<Rigidbody2D>();
            rayTouchingGroundLength = boxCollider.size.y / 2 + 0.05f;
        }

        public void UpdatePlayerPos()
        {
            isWalking = false;

            if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
            {
                if (facingDirection == LEFT)
                {
                    Flip();
                }
                Move(RIGHT);
                isWalking = true;
            }

            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
            {
                if (facingDirection == RIGHT)
                {
                    Flip();
                }
                Move(LEFT);
                isWalking = true;
            }

            if (Input.GetKeyDown(KeyCode.Space) 
                || Input.GetKeyDown(KeyCode.W) 
                || Input.GetKeyDown(KeyCode.UpArrow))
            {
                Jump();
            }
        }

        private void Move(Direction directionX)
        {
            int directionInt = (directionX == RIGHT) ? 1 : -1;
            playerTransform.Translate(directionInt * moveSpeed * Time.deltaTime, 0, 0.0f, Space.World);
        }

        private void Flip()
        {
            facingDirection = (facingDirection == RIGHT) ? LEFT : RIGHT;
            Vector3 theScale = playerTransform.localScale;
            theScale.x *= -1;
            playerTransform.localScale = theScale;
        }

        void Jump()
        {
            if (isNearGround())
            {
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canJumpSecondTime = true;
            }
            else if (canJumpSecondTime)
            {
                this.Stop();
                rigidBody.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
                canJumpSecondTime = false;
            }

        }

        public void Stop()
        {
            rigidBody.velocity = new Vector2(0.0f, 0.0f);
        }

        public bool IsWalking()
        {
            return isWalking;
        }
        public bool isFalling()
        {
            return (rigidBody.velocity.y < -0.5);
        }

        public bool isNearGround()
        {
            RaycastHit2D[] rays = raycastEvenRays(boxCollider.bounds.center, boxCollider.bounds.size, rayNearGroundLength, 3);
            return rays.Any(rayHit => rayHit == true);
        }
        public bool isTouchingGround()
        {
            RaycastHit2D[] rays = raycastEvenRays(boxCollider.bounds.center, boxCollider.bounds.size, rayTouchingGroundLength, 3);
            return rays.Any(rayHit => rayHit == true);
        }

        RaycastHit2D[] raycastEvenRays(Vector2 centeredPosition, Vector2 objectWidth, float rayLength, int raysCount)
        {
            RaycastHit2D[] rays = new RaycastHit2D[raysCount];

            Vector3 rayPosition = centeredPosition;
            rayPosition.x -= objectWidth.x / 2;
            for (int i = 0; i < raysCount; i++)
            {
                rays[i] = Physics2D.Raycast(rayPosition, Vector2.down, rayLength, groundLayer.value);
                Debug.DrawRay(rayPosition, rayNearGroundLength * Vector3.down, Color.white);
                rayPosition.x += objectWidth.x / (raysCount - 1);
            }
            return rays;
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (other.gameObject.CompareTag("Chest"))
            {
                gameObject.GetComponent<SpriteRenderer>().sprite = newSprite;
            }

        }

    }

}
