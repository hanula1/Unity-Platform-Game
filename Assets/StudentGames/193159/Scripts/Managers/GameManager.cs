using System;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace _193159
{
using static GameState;
    public class GameManager : MonoBehaviour
    {
        private static GameManager instance;
        [NonSerialized] public PlayerController player;
        [NonSerialized] public StateManager state;

        private int score = 0;
        private int keysFound = 0;
        private int enemiesKilled = 0;
        public static string highScoreKeyName = "HighScore193159";

        public int GetScore()
        {
            return score;
        }
        public int GetEnemiesKilled()
        {
            return enemiesKilled;
        }
        public int GetKeysFound()
        {
            return keysFound;
        }


        public static GameManager Get()
        {
            return instance;
        }

        private void Start()
        {
            instance = this;
            player = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
            state = GetComponent<StateManager>();

            state.SetState(IN_GAME);

            if (!PlayerPrefs.HasKey(GetCurrentLevelHighscoreKey()))
            {
                PlayerPrefs.SetInt(GetCurrentLevelHighscoreKey(), 0);
            }
        }

        private void Update()
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                RestartLevel();
            }
            if (Input.GetKeyDown(KeyCode.Escape))
            {
                if (state.currentGameState == PAUSE)
                {
                    state.SetState(IN_GAME);
                }
                else
                {
                    state.SetState(PAUSE);
                }
            }
        }

        public void KilledEnemy()
        {
            enemiesKilled++;
        }

        public void AddPoints(int points)
        {
            score += points;
        }
        public void AddKeys(UnityEngine.Color color)
        //public void AddKeys()
        {
            keysFound++;
            InGameMenu.Get().keysTab[keysFound - 1].color = color;
            //keysTab[keysFound - 1].color = UnityEngine.Color.white;
        }
        public void AddKeys()
        {
            keysFound++;
            InGameMenu.Get().keysTab[keysFound - 1].color = UnityEngine.Color.white;
        }


        public void SaveScore()
        {
            int highScore = PlayerPrefs.GetInt(GetCurrentLevelHighscoreKey());
            PlayerPrefs.SetInt(GetCurrentLevelHighscoreKey(), highScore < score ? score : highScore);
        }

        public string GetCurrentLevelHighscoreKey()
        {
            return highScoreKeyName + SceneManager.GetActiveScene().name.Last();
        }

        public void RestartLevel()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }

        public void OnReturnToMainMenuButtonClicked()
        {
            SceneManager.LoadScene("MainMenu");
        }

        public void OnLvl2Clicked()
        {
            SceneManager.LoadScene("Level2");
        }

        public void OnLvl3Clicked()
        {
            SceneManager.LoadScene("Level3");
        }
        public void OnLvl4Clicked()
        {
            SceneManager.LoadScene("Level4_koniec");
        }
    }
}
