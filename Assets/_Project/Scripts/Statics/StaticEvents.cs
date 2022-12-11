using System;
using _Project.Scriptable_Objects.So_Scripts;
using _Project.Scripts.UI;

namespace Statics
{
    public static class StaticEvents
    {
        public static Action<int> OnLevelChanged;
        public static Action OnPreGameStarted;
        public static Action OnTappedToPlay;
        public static Action OnArrivedFinish;
        public static Action OnNextButtonClicked;
        public static Action OnPlayerAttack;
        public static Action OnBossDefeated;
        
        // SHOP
        
        public static Func<StatUpgradeData, bool> OnTryUpgradeStat;
        public static Action OnUpgradeSuccess;
    }
}

