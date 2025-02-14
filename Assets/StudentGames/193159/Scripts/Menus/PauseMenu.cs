using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace _193159
{
    public class PauseMenu : MonoBehaviour
    {
        [SerializeField] public Canvas canvas;

        public static PauseMenu instance;
        public static PauseMenu Get()
        {
            return instance;
        }
        public void Awake()
        {
            instance = this;
        }
        public void SetActive(bool isActive)
        {
            canvas.enabled = isActive;
            canvas.gameObject.SetActive(isActive);
        }
        public void OnExitToDesktopButtonPressed()
        {
            #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
            #endif
            Application.Quit();
        }
        public void OnResumeButtonClicked()
        {
            StateManager.Get().SetState(GameState.IN_GAME);
        }

        public void OnRestartButtonClicked()
        {
            GameManager.Get().RestartLevel();
        }

    }
}