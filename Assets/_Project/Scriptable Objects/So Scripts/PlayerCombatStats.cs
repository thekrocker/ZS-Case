using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scriptable_Objects.So_Scripts
{
    [CreateAssetMenu(menuName = "Player/Combat")]
    public class PlayerCombatStats : ScriptableObject
    {
        public float initialDamage;
        [ReadOnly] [SerializeField] private float currentDamage;

        public float initialAttackRate = 1f;
        [ReadOnly] [SerializeField] private float currentAttackRate;


        public Action<float> OnDamageChanged;
        public Action<float> OnCurrentAttackRateChanged;
        public float CurrentDamage
        {
            get => currentDamage;
            set
            {
                currentDamage = value;
                OnDamageChanged?.Invoke(currentDamage);
                SaveDamage();
            }
        }

        public float CurrentAttackRate
        {
            get => currentAttackRate;
            set
            {
                currentAttackRate = Mathf.Clamp(value, 0.1f, 100f);
                OnCurrentAttackRateChanged?.Invoke(currentAttackRate);
                SaveAttackRate();
            }
        }

        public void SaveDamage()
        {
            PlayerPrefs.SetFloat(nameof(CurrentDamage), CurrentDamage);
        }

        public void SaveAttackRate()
        {
            PlayerPrefs.SetFloat(nameof(CurrentAttackRate), CurrentAttackRate);

        }
        public void LoadDamage()
        {
            CurrentDamage = PlayerPrefs.GetFloat(nameof(CurrentDamage), initialDamage);
        }

        public void LoadAttackRate()
        {
            CurrentAttackRate = PlayerPrefs.GetFloat(nameof(CurrentAttackRate), initialAttackRate);
        }
    }
}