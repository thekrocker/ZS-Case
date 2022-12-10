using System;
using Manager;
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

        private Vector3 _firstPosition, _deltaPosition;
        private float _destinationX;
        private bool _isDragging;
        
        private float _xClampValue;
        //Input refs
        private PlayerInputHandler _inputHandler;
        private void Awake()
        {
            _inputHandler = GetComponent<PlayerInputHandler>();
        }

        private void Start()
        {
            CalculateClampValue();
        }
        
        private void OnEnable()
        {
            _inputHandler.OnStartDrag += StartDrag;
            _inputHandler.OnEndDrag += EndDrag;
        }
        
        private void CalculateClampValue()
        {
            float offset = .5f;
            _xClampValue = (GameManager.Instance.GetPlatformWidth() / 2f) - offset;
        }
        
        public void TryMove()
        {
            MoveForward();
            if (_isDragging) HandleXMovement();
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

        private void HandleXMovement()
        {

            // Calculate mouse delta
            Vector3 mousePos = _inputHandler.GetMousePos();
            _deltaPosition = mousePos - _firstPosition;
            _deltaPosition.y = 0f;
            _firstPosition = mousePos;
            
            // Calculate X destination
            _destinationX = _deltaPosition.x * (stats.xSensivity * Time.deltaTime);
            _destinationX = Mathf.Clamp(_destinationX, -_xClampValue, _xClampValue);
            model.Translate(_destinationX, 0f, 0f);

            // Clamp x 
            Vector3 clamp = model.transform.position;
            clamp.x = Mathf.Clamp(clamp.x, -_xClampValue, _xClampValue);
            model.transform.position = clamp;
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

