using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Enemy;
using Manager;
using Statics;
using UnityEngine;


public class Boss : MonoBehaviour, IDamageable<float>
{
    // REFACTOR LATER TO boss anim controller
    [SerializeField] private Animator animator;
    private static readonly int DieTrigger = Animator.StringToHash("dieTrigger");

    public Health Health { get; set; }

    private void Awake()
    {
        Health = GetComponent<Health>();
        BossManager.Instance.DamageableBoss = this;
    }

    private void OnEnable()
    {
        Health.OnDied += OnDie;
        Health.OnDamage += OnBossDamaged;
    }

    private void OnBossDamaged()
    {
        // Play shader or smth..
    }

    private void OnDie()
    {
        StaticEvents.OnBossDefeated?.Invoke();
        animator.SetTrigger(DieTrigger);
        Debug.Log("Boss Died"); 
    }

    public void Damage(float amount)
    {
        Health.Damage(amount);
    }
    
    private void OnDisable()
    {
        Health.OnDied -= OnDie;
        Health.OnDamage -= OnBossDamaged;
    }
}
