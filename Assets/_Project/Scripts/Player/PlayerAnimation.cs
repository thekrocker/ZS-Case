using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private Animator animator;
    
    private static readonly int IsMoving = Animator.StringToHash("isMoving");
    private static readonly int DanceTrigger = Animator.StringToHash("danceTrigger");

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
}
