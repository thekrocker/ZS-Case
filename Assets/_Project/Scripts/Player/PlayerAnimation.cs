using System;
using _Project.Scripts.EventArgs;
using Statics;
using UnityEngine;
using Random = UnityEngine.Random;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    [SerializeField] private Resource diamondResource;
    
private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int DanceTrigger = Animator.StringToHash("danceTrigger");
    private static readonly int PunchRightTrigger = Animator.StringToHash("punchRightTrigger");
    private static readonly int PunchLeftTrigger = Animator.StringToHash("punchLeftTrigger");
    private static readonly int KickTrigger = Animator.StringToHash("kickTrigger");
    private static readonly int StackVelocity = Animator.StringToHash("stackVelocity");
    private static readonly int DefeatTrigger = Animator.StringToHash("defeatTrigger");

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
        StaticEvents.OnPlayerLose += PlayDefeatAnim;
        diamondResource.OnValueChanged += PlayMoveBlend;
    }

    private void PlayDefeatAnim()
    {
        if (animator == null) return;
        animator.SetTrigger(DefeatTrigger);
    }

    private void PlayMoveBlend(object sender, ResourceArgs e)
    {
        if (animator == null) return;
        animator.SetFloat(StackVelocity, (float) e.Current / (float) e.Max);
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
        StaticEvents.OnArrivedFinish -= PlayIdle;
        StaticEvents.OnBossDefeated -= SetDanceAnim;
        StaticEvents.OnPlayerLose -= PlayDefeatAnim;
        diamondResource.OnValueChanged -= PlayMoveBlend;

    }
}