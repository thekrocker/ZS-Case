using System;
using Statics;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.Input
{
    public class PlayerInputHandler : MonoBehaviour
    {
        private Player_InputAction _inputAction;

        public Action OnStartDrag;
        public Action OnEndDrag;
        public Action OnTapAction;
        
        private void Awake()
        {
            _inputAction = new Player_InputAction();
            
            _inputAction.Gameplay.OnDragStart.performed += OnDragStart;
            _inputAction.Gameplay.OnDragEnd.performed += OnDragEnd;
            _inputAction.BossFight.OnTap.performed += OnTap;
        }
        
        private void OnEnable()
        {
            _inputAction.Gameplay.Enable();
            
            StaticEvents.OnArrivedFinish += DisableMovementInput;
            StaticEvents.OnArrivedFinish += ActivateBossFightInput;
            StaticEvents.OnBossDefeated += DisableBossFightInput;
        }

        private void ActivateBossFightInput()
        {
            _inputAction.BossFight.Enable();
        }

        private void DisableMovementInput()
        {
            _inputAction.Gameplay.Disable();
        }

        private void DisableBossFightInput()
        {
            _inputAction.BossFight.Disable();
        }

        public Vector3 GetMousePos()
        {
            return Mouse.current.position.ReadValue();
        }

        private void OnDragStart(InputAction.CallbackContext obj)
        {
            OnStartDrag?.Invoke();
        }
        
        private void OnDragEnd(InputAction.CallbackContext obj)
        {
            OnEndDrag?.Invoke();
        }
        
        private void OnTap(InputAction.CallbackContext obj)
        {
            OnTapAction?.Invoke();
            Debug.Log("Tap input activated..");
        }

        private void OnDisable()
        {
            DisableMovementInput();
            DisableBossFightInput();
            
            StaticEvents.OnArrivedFinish -= DisableMovementInput;
            StaticEvents.OnArrivedFinish -= ActivateBossFightInput;
            StaticEvents.OnBossDefeated -= DisableBossFightInput;
        }
    }
}