using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scriptable_Objects.So_Scripts;
using Helpers;
using Statics;
using UnityEngine;

namespace Manager
{
    [DefaultExecutionOrder(-360)]
    public class GameManager : SingletonClass.Singleton<GameManager>
    {
        [SerializeField] private Resource currencyGold;
        [SerializeField] private BoxCollider platformTemplate;
        
        public float GetPlatformLength() => platformTemplate.size.z;
        public float GetPlatformWidth() => platformTemplate.size.x;


        private void OnEnable()
        {
            StaticEvents.OnTryUpgradeStat += TryUpgradeStat;
        }

        private bool TryUpgradeStat(StatUpgradeData data)
        {
            if (currencyGold.CanAfford(data.Cost))
            {
                currencyGold.Decrease(data.cost);
                data.UpgradeAvailable();
                return true;
            }

            Debug.Log("Not Enough");
            return false;
        }

        private void OnDisable()
        {
            StaticEvents.OnTryUpgradeStat -= TryUpgradeStat;
        }
        // I would create SHOPManager to handle economy later..
        
    }
}