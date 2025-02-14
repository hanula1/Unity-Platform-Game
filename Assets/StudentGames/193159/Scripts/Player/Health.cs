using System;
using UnityEngine;


namespace _193159
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private int startingHealth;
        [SerializeField] public int maxHealth;

        public int lives { private set; get; }

        void Start()
        {
            lives = startingHealth;
        }

        public void Heal()
        {
            if (lives < startingHealth)
            {
                lives++;
            }
        }

        public void TakeDamage()
        {
            lives--;
        }

        public bool IsDead()
        {
            return lives == 0;
        }
    }
}
