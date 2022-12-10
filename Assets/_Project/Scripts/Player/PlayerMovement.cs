using System;
using Player.PlayerInput;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Player.PlayerMovement
{
    [RequireComponent(typeof(PlayerInputHandler))]
    public class PlayerMovement : MonoBehaviour
    {
        [SerializeField] private float xSensivity;
        [SerializeField] private float xClampValue;

        private Vector3 _firstPosition, _deltaPosition, _destinationPosition;
        private bool _isDragging;
        
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
            if (_isDragging) Drag();
        }

        private void StartDrag()
        {
            _isDragging = true;
            _firstPosition = _inputHandler.GetMousePos();
        }

        private void Drag()
        {
            Vector3 mousePos = _inputHandler.GetMousePos();
            
            _deltaPosition = mousePos - _firstPosition;
            _deltaPosition.y = 0f;
            _firstPosition = mousePos;

            _destinationPosition = transform.position + _deltaPosition * (xSensivity * Time.deltaTime);
            _destinationPosition.x = Mathf.Clamp(_destinationPosition.x, -xClampValue, xClampValue);
            transform.position = _destinationPosition;
        }
        
        private void EndDrag()
        {
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

