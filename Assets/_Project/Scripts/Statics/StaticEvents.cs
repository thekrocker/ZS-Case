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
        public static Action<bool> OnBossStageEnded; // Holds the bool if we win or lose as arg
        public static Action OnBossDefeated;
        public static Action OnPlayerLose;
        public static Action OnNextLevelInit;
        public static Action OnCoinAnimCompleted;
        
        // SHOP
        
        public static Func<StatUpgradeData, bool> OnTryUpgradeStat;
        public static Action OnUpgradeSuccess;

        // CAM
        public static Action OnInGameCamBlent;
        public static Action<bool> OnEndGameCamBlent; // Holds the bool if we win or lose as arg

    }
}

