using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scriptable_Objects.So_Scripts
{
    [CreateAssetMenu(menuName = "UpgradeSystem/Stat Upgrade")]
    public class StatUpgradeData : BaseUpgradeData
    {
        [Title("Stat Properties")] 
        public float statIncreaseRate;
        
        public Action<float> OnUpgradeAvailable;

        public void UpgradeAvailable()
        {
            OnUpgradeAvailable?.Invoke(statIncreaseRate);
        }
    }
}