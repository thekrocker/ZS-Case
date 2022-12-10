using System;
using Statics;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public class EndGamePanel : BasePanel
    {
        [SerializeField] private Button nextButton;

        private void OnEnable()
        {
            nextButton.onClick.AddListener(OnClickNext);
        }

        private void OnClickNext()
        {
            StaticEvents.OnNextButtonClicked?.Invoke();
        }

        private void OnDisable()
        {
            nextButton.onClick.RemoveListener(OnClickNext);
        }
    }
}