using _Project.Scriptable_Objects.So_Scripts;
using Sirenix.OdinInspector;
using Statics;
using TMPro;
using UnityEngine;

namespace _Project.Scripts.UI
{
    public class StatUpgradeUI : BaseUpgradeUI
    {
        [Title("Stat Properties")]
        [TextArea(2,3)]
        [SerializeField] private string infoText;
        [SerializeField] private StatUpgradeData statData;
        [SerializeField] private TextMeshProUGUI statUpgradeText;

        protected override void Start()
        {
            base.Start();
            LoadStats();
            SetCostText(statData.cost);
            SetLevelText(statData.level);
            SetStatInfo();
            SetUpgradeSprite();
        }

        private void LoadStats()
        {
            statData.LoadStats();
        }

        protected override void OnEnable()
        {
            base.OnEnable();
            
            statData.OnLevelChanged += SetLevelText;
            statData.OnCostChanged += SetCostText;
        }

        protected override void OnClickButton()
        {
            base.OnClickButton();
            
            if (!StaticEvents.OnTryUpgradeStat.Invoke(statData))
            {
                Debug.LogWarning("Can not afford. Set some UI effect later");
            }
            else
            {
                Debug.Log("Successfully bought! Do some positive effects.");
            }
        }

        protected override void SetCostText(int amount)
        {
            costText.text = $"{statData.Cost}";
        }

        protected override void SetLevelText(int amount)
        {
            levelText.text = $"Level {statData.Level}";
        }

        protected override void SetUpgradeSprite()
        {
            upgradeImg.sprite = statData.sprite;
        }

        private void SetStatInfo()
        {
            statUpgradeText.text = $"{infoText} {statData.statIncreaseRate}";
        }
    }
}