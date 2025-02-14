using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace _193159
{
    class LevelCompletedMenu : MonoBehaviour
    {
        [SerializeField] public Canvas canvas;
        [SerializeField] public TMP_Text timerText;
        [SerializeField] public TMP_Text highScoreText;
        [SerializeField] public TMP_Text yourScoreText;

        public static LevelCompletedMenu instance;
        public static LevelCompletedMenu Get()
        {
            return instance;
        }
        public void Awake()
        {
            instance = this;
        }

        public void SetActive(bool isActive)
        {
            if(isActive)
            {
                Show();
            }
            canvas.enabled = isActive;
            canvas.gameObject.SetActive(isActive);
        }

        private void Show()
        {
            Scene currentScene = SceneManager.GetActiveScene();
            int score = GameManager.Get().GetScore();

            timerText.text = InGameMenu.Get().timerText.text;
            yourScoreText.text = "Your score: " + score.ToString();
            highScoreText.text = "The best score: " + PlayerPrefs.GetInt(GameManager.Get().GetCurrentLevelHighscoreKey()).ToString();
        }

    }
}
