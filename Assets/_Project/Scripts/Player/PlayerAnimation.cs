using System;
using Statics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;

    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int DanceTrigger = Animator.StringToHash("danceTrigger");
    private static readonly int PunchRightTrigger = Animator.StringToHash("punchRightTrigger");
    private static readonly int PunchLeftTrigger = Animator.StringToHash("punchLeftTrigger");
    private static readonly int KickTrigger = Animator.StringToHash("kickTrigger");

    private int[] _attackTriggers;

    private void Awake()
    {
        _attackTriggers = new[]
        {
            PunchLeftTrigger,
            PunchRightTrigger,
            KickTrigger
        };
    }

    private void OnEnable()
    {
        StaticEvents.OnPreGameStarted += PlayIdle;
        StaticEvents.OnInGameCamBlent += PlayMove;
        StaticEvents.OnPlayerAttack += SetAttackAnim;
        StaticEvents.OnBossDefeated += SetDanceAnim;
        StaticEvents.OnArrivedFinish += PlayIdle;
    }

    private void DecideMoveAnim(bool s)
    {
        if (animator == null) return;
        animator.SetBool(IsMoving, s);
    }

    public void PlayIdle()
    {
        DecideMoveAnim(false);
    }

    public void PlayMove()
    {
        DecideMoveAnim(true);
    }

    public void SetDanceAnim()
    {
        if (animator == null) return;
        animator.SetTrigger(DanceTrigger);
    }

    public void SetAttackAnim()
    {
        if (animator == null) return;
        animator.SetTrigger(_attackTriggers[Random.Range(0, _attackTriggers.Length)]);
    }

    private void OnDisable()
    {
        StaticEvents.OnPreGameStarted -= PlayIdle;
        StaticEvents.OnInGameCamBlent -= PlayMove;
        StaticEvents.OnPlayerAttack -= SetAttackAnim;
        StaticEvents.OnBossDefeated -= SetDanceAnim;
        StaticEvents.OnArrivedFinish -= PlayIdle;
    }
}