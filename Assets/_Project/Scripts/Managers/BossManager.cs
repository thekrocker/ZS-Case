using System;
using Helpers;
using Statics;
using UnityEngine;

namespace Manager
{
    [DefaultExecutionOrder(-345)]
    public class BossManager : SingletonClass.Singleton<BossManager>
    {
        [SerializeField] private float bossHpIncreaseRate;
        
        public IDamageable<float> DamageableBoss;

        private void OnEnable()
        {
            //TODO: Upgrade boss in game ended..
            StaticEvents.OnBossDefeated += UpgradeBoss;
        }

        public void UpgradeBoss()
        {
            DamageableBoss.Health.UpgradeInitialHealth(bossHpIncreaseRate);
        }

        private void OnDisable()
        {
            StaticEvents.OnBossDefeated -= UpgradeBoss;
        }
    }
}