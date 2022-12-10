using System;
using Player.Input;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player
{
    [RequireComponent(typeof(PlayerInputHandler))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private Transform model;
        [SerializeField] private PlayerMovementStats stats;

        private Vector3 _firstPosition, _deltaPosition, _destinationPosition;
        private bool _isDragging;
        
        //Input refs
        private PlayerInputHandler _inputHandler;
        
        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
        }

        private void OnEnable()
        {
            _inputHandler.OnStartDrag += StartDrag;
            _inputHandler.OnEndDrag += EndDrag;
        }

        private void Update()
        {
            MoveForward();
            if (_isDragging) Drag();
        }

        private void MoveForward()
        {
            transform.position += transform.forward * (stats.moveSpeed * Time.deltaTime);
        }

        private void StartDrag()
        {
            _isDragging = true;
            _firstPosition = _inputHandler.GetMousePos();
        }

        private void Drag()
        {
            // Calculates delta between first & drag position, add it to pos X.
            
            Vector3 mousePos = _inputHandler.GetMousePos();
            
            _deltaPosition = mousePos - _firstPosition;
            _deltaPosition.y = 0f;
            _firstPosition = mousePos;

            _destinationPosition = model.position + _deltaPosition * (stats.xSensivity * Time.deltaTime);
            _destinationPosition.x = Mathf.Clamp(_destinationPosition.x, -stats.xClampValue, stats.xClampValue);
            model.position = _destinationPosition;
        }
        
        private void EndDrag()
        {
            // Reset input values
            _isDragging = false;
            _firstPosition = _inputHandler.GetMousePos();
            _deltaPosition = Vector3.zero;
        }

        private void OnDisable()
        {
            _inputHandler.OnStartDrag -= StartDrag;
            _inputHandler.OnEndDrag -= EndDrag;
        }
    }  
}

