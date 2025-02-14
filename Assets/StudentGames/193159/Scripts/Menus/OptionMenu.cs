using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
namespace _193159
{
    public class OptionMenu : MonoBehaviour
    {
        [SerializeField] public Canvas canvas;
        [SerializeField] private TMP_Text qualityText;

        public static OptionMenu instance;
        public static OptionMenu Get()
        {
            return instance;
        }
        public void Awake()
        {
            instance = this;
            qualityText.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
        }
        public void SetActive(bool isActive)
        {
            canvas.enabled = isActive;
            canvas.gameObject.SetActive(isActive);
        }

        public void OnOptionsButtonClicked()
        {
            StateManager.Get().SetState(GameState.OPTIONS);
        }

        public void OnMinusButtonClicked()
        {
            QualitySettings.DecreaseLevel();
            qualityText.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
        }

        public void OnPlusButtonClicked()
        {
            QualitySettings.IncreaseLevel();
            qualityText.text = QualitySettings.names[QualitySettings.GetQualityLevel()];
        }

        public void OnResumeButtonClicked()
        {
            StateManager.Get().SetState(GameState.IN_GAME);
        }
    }
}