using UnityEngine;

namespace _Project.Scripts.Upgrades
{
    public class StackSizeUpgrader : BaseStatUpgrader
    {
        [SerializeField] private Resource stack;
        
        public override void Upgrade()
        {
            stack.UpgradeInitial(Mathf.RoundToInt(upgradeData.statIncreaseRate));
        }
    }
}