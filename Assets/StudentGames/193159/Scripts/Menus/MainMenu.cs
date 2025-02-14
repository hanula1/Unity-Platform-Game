using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace _193159
{
    public class MainMenu : MonoBehaviour
    {
        public void OnLevel1ButtonPressed()
        {
            SceneManager.LoadScene("Level1");
        }

        public void OnLevel2ButtonPressed()
        {
            SceneManager.LoadScene("Level2");
        }

        public void OnLevel3ButtonPressed()
        {
            SceneManager.LoadScene("Level3");
        }

        public void OnExitToDesktopButtonPressed()
        {
        #if UNITY_EDITOR
            UnityEditor.EditorApplication.isPlaying = false;
        #endif
            Application.Quit();
        }
    }
}
