using System;
using Player.Input;
using UnityEngine;

namespace _Project.Scripts.Player
{
    [RequireComponent(typeof(PlayerInputHandler))]
    public class PlayerCombat : MonoBehaviour
    {
        private PlayerInputHandler _inputHandler;
        private PlayerAnimation _animation;
        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
            _animation = GetComponent<PlayerAnimation>();
        }

        private void OnEnable()
        {
            _inputHandler.OnTapAction += OnAttack;
        }

        private void OnAttack()
        {
            _animation.SetAttackAnim();
        }

        private void OnDisable()
        {
            _inputHandler.OnTapAction -= OnAttack;
        }
    }
}