using UnityEngine;

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

    public void SetMoveAnim(bool s)
    {
        if (animator == null) return;
        animator.SetBool(IsMoving, s);
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
}
