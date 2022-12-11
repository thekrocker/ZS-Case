using System;
using Sirenix.OdinInspector;
using UnityEngine;

namespace _Project.Scripts.Enemy
{
    public class Health : MonoBehaviour
    {
        [SerializeField] private FloatValue initial;
        [ReadOnly] [SerializeField] private float currentHp;

        public Action OnDamage;
        public Action OnDied;
        public float CurrentHp
        {
            get => currentHp;
            set
            {
                currentHp = value;
            }
        }

        public bool IsDead => CurrentHp <= 0f;

        public float Ratio => CurrentHp / initial.floatValue;
        private void Start()
        {
            LoadInitial();
            CurrentHp = initial.floatValue;
        }

        private void LoadInitial()
        {
            initial.floatValue = PlayerPrefs.GetFloat(nameof(initial), 100);
        }

        public void Damage(float amount)
        {
            if (CurrentHp <= 0) return;
            
            CurrentHp -= amount;
            OnDamage?.Invoke();
            
            if (CurrentHp <= 0)
            {
                CurrentHp = 0;
                OnDied?.Invoke();
            }
        }

        public void UpgradeInitialHealth(float amount)
        {
            initial.floatValue += amount;
            SaveInitial();
        }

        public void SaveInitial()
        {
            PlayerPrefs.SetFloat(nameof(initial), initial.floatValue);
        }
    }
}