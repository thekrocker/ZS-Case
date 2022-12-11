using _Project.Scriptable_Objects.So_Scripts;
using UnityEngine;

namespace _Project.Scripts.Upgrades
{
    public class AttackRateUpgrader : BaseStatUpgrader
    {
        [SerializeField] private PlayerCombatStats stats;

        public override void Upgrade()
        {
            stats.CurrentAttackRate -= upgradeData.statIncreaseRate;
        }
    }
}