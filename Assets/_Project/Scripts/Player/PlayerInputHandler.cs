using System;
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
        }

        public Vector3 GetMousePos() => Mouse.current.position.ReadValue();
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
            _inputAction.Disable();
        }
    }
}