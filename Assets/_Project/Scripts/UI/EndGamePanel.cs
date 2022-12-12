using System;
using _Project.Scriptable_Objects.So_Scripts;
using Statics;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.UI
{
    public abstract class EndGamePanel : BasePanel
    {
        [SerializeField] private TextMeshProUGUI earnedGoldText;
        [SerializeField] private GameObject goldEarnedArea;
        [SerializeField] private Button nextButton;
        [SerializeField] private CollectableEconomySo goldEconomy;
        

        protected virtual void OnEnable()
        {
            DisableNextButton();
            nextButton.onClick.AddListener(OnClickNextButton);
            StaticEvents.OnCoinAnimCompleted += EnableNextButton;
            EnableEarnedGoldArea();
        }

        protected void EnableEarnedGoldArea()
        {
            earnedGoldText.text = $"{LevelController.GainedCoin}";
            goldEarnedArea.SetActive(true);
        }

        protected void EnableNextButton()
        {
            nextButton.gameObject.SetActive(true);
        }
        
        protected void DisableNextButton()
        {
            nextButton.gameObject.SetActive(false);
        }
        

        protected virtual void OnClickNextButton()
        {
            StaticEvents.OnNextButtonClicked?.Invoke();
        }

        protected virtual void OnDisable()
        {
            nextButton.onClick.RemoveListener(OnClickNextButton);
            StaticEvents.OnCoinAnimCompleted -= EnableNextButton;
        }
    }
}