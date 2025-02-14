using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TMPro;
using UnityEngine.UI;
using UnityEngine;
namespace _193159
{
    class InGameMenu : MonoBehaviour
    {
        [SerializeField] public Canvas canvas;

        [SerializeField] public TMP_Text scoreText;
        [SerializeField] public TMP_Text enemiesText;
        [SerializeField] public TMP_Text timerText;

        public Stopwatch timer;
        [SerializeField] public Image[] keysTab;
        [SerializeField] public Image[] livesTab;

        public static InGameMenu instance;
        public static InGameMenu Get()
        {
            return instance;
        }
        public void Awake()
        {
            instance = this;
            timer = new Stopwatch();
            timer.Start();

            keysTab.ToList().ForEach(key => key.color = Color.grey);
            livesTab.ToList().ForEach(image => image.enabled = true);
        }

        public void SetActive(bool isActive)
        {
            canvas.enabled = isActive;
            canvas.gameObject.SetActive(isActive);
        }

        void Update()
        {
            string timeText = string.Format("{0:00}:{1:00}", timer.Elapsed.Minutes, timer.Elapsed.Seconds);
            timerText.text = timeText;

            livesTab.ToList().ForEach(image => image.enabled = false);
            for (int i = 0; i < GameManager.Get().player.health.lives; i++)
            {
                livesTab[i].enabled = true;
            }

            scoreText.text = GameManager.Get().GetScore().ToString();
            enemiesText.text = GameManager.Get().GetEnemiesKilled().ToString();
        }

    }
}
