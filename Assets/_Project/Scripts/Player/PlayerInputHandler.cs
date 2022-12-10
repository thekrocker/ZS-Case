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
        
        private void Awake()
        {
            _inputAction = new Player_InputAction();
            _inputAction.Gameplay.OnDragStart.performed += OnDragStart;
            _inputAction.Gameplay.OnDragEnd.performed += OnDragEnd;
        }

        private void OnEnable()
        {
            _inputAction.Enable();
            StaticEvents.OnGameEnded += DisableInput;
        }

        private void DisableInput()
        {
            _inputAction.Disable();
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

        private void OnDisable()
        {
            DisableInput();
            StaticEvents.OnGameEnded -= DisableInput;
        }
    }
}