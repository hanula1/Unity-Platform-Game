using UnityEngine;
namespace _193159
{
    public enum GameState
    {
        PAUSE,
        IN_GAME,
        LEVEL_COMPLETED,
        GAME_OVER,
        OPTIONS
    };

    public class StateManager : MonoBehaviour
    {
        public GameState currentGameState { get; private set; }

        private static StateManager instance;
        public static StateManager Get()
        {
            return instance;
        }
        public void Awake()
        {
            instance = this;
        }

        public void SetState(GameState newGameState)
        {
            ResetBeforeGameSateChange();
            currentGameState = newGameState;
            switch(newGameState)
            {
                case GameState.PAUSE:
                    setPause();
                    break;
                case GameState.IN_GAME:
                    setInGame();
                    break;
                case GameState.LEVEL_COMPLETED:
                    setLevelCompleted();
                    break;
                case GameState.GAME_OVER:
                    setGameOver();
                    break;
                case GameState.OPTIONS:
                    setOptions();
                    break;
            }
        }
        private void ResetBeforeGameSateChange()
        {
            PauseMenu.Get().SetActive(false);
            LevelCompletedMenu.Get().SetActive(false);
            OptionMenu.Get().SetActive(false);
            InGameMenu.Get().SetActive(false);
            InGameMenu.Get().timer.Stop();
            Time.timeScale = 0;
        }
        private void setPause()
        {
            PauseMenu.Get().SetActive(true);
        }

        private void setInGame()
        {
            Time.timeScale = 1;
            InGameMenu.Get().timer.Start();
            InGameMenu.Get().SetActive(true);
        }

        private void setLevelCompleted()
        {
            LevelCompletedMenu.Get().SetActive(true);
        }

        private void setGameOver()
        {
            // TODO: implement gameOverScreen //
        }

        private void setOptions()
        {
            OptionMenu.Get().SetActive(true);
        }

    }
}
