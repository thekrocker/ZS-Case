using System;
using System.Collections;
using System.Collections.Generic;
using _Project.Scripts.Enemy;
using Manager;
using Statics;
using UnityEngine;
using Random = UnityEngine.Random;

[Serializable]
public class BossVisualProperties
{
    public Color[] rndColors;
    public SkinnedMeshRenderer mRenderer;

    public Color SetRandomColor()
    {
        SetColor(rndColors[Random.Range(0, rndColors.Length)]);
        return mRenderer.material.color;
    }

    public void SetColor(Color c)
    {
        mRenderer.material.color = c;
    }

    public void SetDamageColor()
    {
        SetColor(Color.white);
    }
}

public class Boss : MonoBehaviour, IDamageable<float>
{
    // REFACTOR LATER TO boss anim controller
    [SerializeField] private Animator animator;
    [SerializeField] private BossVisualProperties visualProperties;


    private static readonly int DieTrigger = Animator.StringToHash("dieTrigger");
    private static readonly int RoarTrigger = Animator.StringToHash("roarTrigger");
    private static readonly int HitTrigger = Animator.StringToHash("hitTrigger");

    public Health Health { get; set; }

    private Color _initialColor;
    
    private void Awake()
    {
        Health = GetComponent<Health>();
        SetCurrentBoss();
        _initialColor =SetRndColor();
    }

    private void OnEnable()
    {
        Health.OnDied += OnDie;
        Health.OnDamage += OnBossDamaged;
    }


    private Color SetRndColor()
    {
        return visualProperties.SetRandomColor();
    }

    private void SetDamageColor()
    {
        WaitForSeconds delay = new WaitForSeconds(0.07f);
        StartCoroutine(IESetDamageColor());

        IEnumerator IESetDamageColor()
        {
            visualProperties.SetDamageColor();
            yield return delay;
            visualProperties.SetColor(_initialColor);
        }
    }

    private void SetCurrentBoss()
    {
        BossManager.Instance.DamageableBoss = this;
    }


    private void OnBossDamaged()
    {
        SetDamageColor();

        if (Health.CurrentHp <= 0)
        {
            animator.SetTrigger(DieTrigger);
        }
        else
        {
            animator.SetTrigger(HitTrigger);
        }
    }

    private void OnDie()
    {
        StaticEvents.OnBossDefeated?.Invoke();
    }


    public void RoarAnim() // Unity event by trigger
    {
        animator.SetTrigger(RoarTrigger);
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