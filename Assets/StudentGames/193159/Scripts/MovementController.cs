namespace _193159
{
    using System;
    using UnityEngine;
    using static Direction;
    class MovementController : MonoBehaviour
    {
        [Header("Movement parameters")]
        [Range(0.01f, 20.0f)] [SerializeField] private float moveSpeed;
        [SerializeField] private Direction facingDirectionInTheSprite = Direction.RIGHT;


        public float moveRange;
    
        private float startingPoint;
        private Direction facingDirection = RIGHT;

        void Awake()
        {
            startingPoint = transform.position.x;
        }

        private void Start()
        {
            facingDirection = facingDirectionInTheSprite;
        }

        void Update()
        {
            if (facingDirection == RIGHT)
            {
                if (transform.position.x < startingPoint + moveRange)
                {
                    MoveRight();
                }
                else
                {
                    MoveLeft();
                }
            }
            else
            {
                if (transform.position.x > startingPoint - moveRange)
                {
                    MoveLeft();
                }
                else
                {
                    MoveRight();
                }
            }
        }

        private void MoveRight()
        {
            if (facingDirection == LEFT)
            {
                Flip();
            }    
            transform.Translate(moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }
        private void MoveLeft()
        {
            if (facingDirection == RIGHT)
            {
                Flip();
            }
            transform.Translate((-1) * moveSpeed * Time.deltaTime, 0.0f, 0.0f, Space.World);
        }   

        private void Flip()
        {
            facingDirection = (facingDirection == RIGHT) ? LEFT : RIGHT;
            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }

    }
}
