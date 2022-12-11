using System;
using Statics;
using UnityEngine;
using UnityEngine.UI;

namespace _Project.Scripts.Enemy
{
    [RequireComponent(typeof(Health))]
    public class HealthBar : MonoBehaviour
    {
        [SerializeField] private Image fillImg;

        private Health _health;

        private void Awake()
        {
            _health = GetComponent<Health>();
        }

        private void Start()
        {
            SetHealthBar();
        }

        private void OnEnable()
        {
            _health.OnDamage += SetHealthBar;
        }

        private void OnDisable()
        {
            _health.OnDamage -= SetHealthBar;
        }

        private void SetHealthBar()
        {
            fillImg.fillAmount = _health.Ratio;
        }
    }
}