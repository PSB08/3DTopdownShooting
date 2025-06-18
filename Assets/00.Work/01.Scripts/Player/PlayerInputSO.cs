using System;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Player
{
    [CreateAssetMenu(fileName = "SO", menuName = "PlayerInputSO", order = 0)]
    public class PlayerInputSO : ScriptableObject, Controls.IPlayerActions
    {
        public event Action OnAttackPressed;
        public event Action OnDashPressed;

        public Vector2 MovementKey { get; private set; }
        
        private Controls _controls;
        private Vector2 _screenPosition;
        private Vector3 _worldPosition;

        private void OnEnable()
        {
            if (_controls == null)
            {
                _controls = new Controls();
                _controls.Player.SetCallbacks(this);
            }
            _controls.Player.Enable();
        }

        private void OnDisable()
        {
            _controls.Player.Disable();
        }

        public void OnMove(InputAction.CallbackContext context)
        {
            MovementKey = context.ReadValue<Vector2>();
        }

        public void OnAttack(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnAttackPressed?.Invoke();
        }

        public void OnDash(InputAction.CallbackContext context)
        {
            if (context.performed)
                OnDashPressed?.Invoke();
        }
        
    }
}