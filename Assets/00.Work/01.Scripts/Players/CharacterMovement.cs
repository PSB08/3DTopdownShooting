﻿using Code.Entities;
using UnityEngine;

namespace Code.Players
{
    public class CharacterMovement : MonoBehaviour, IEntityComponent, IAfterInitialize
    {
        //[SerializeField] private StatSO moveSpeedStat;
   //private EntityStat _statCompo;
        [SerializeField] private float gravity = -9.8f;
        [SerializeField] private CharacterController controller;

        public bool IsGround => controller.isGrounded;
        public bool CanManualMovement { get; set; } = true;
        private Vector3 _autoMovement;
    
        private float _moveSpeed = 8f;
        private Vector3 _velocity;
        public Vector3 Velocity => _velocity;
        private float _verticalVelocity;
        private Vector3 _movementDirection;

        private Entity _entity;
        public void Initialize(Entity entity)
        {
            _entity = entity;
            //_statCompo = entity.GetCompo<EntityStat>();
        }
    
        public void AfterInitialize()
        {
            //_moveSpeed = _statCompo.SubscribeStat(moveSpeedStat, HandleMoveSpeedChange, 1f);
        }

        private void OnDestroy()
        { 
            //_statCompo.UnSubscribeStat(moveSpeedStat, HandleMoveSpeedChange);
        }

        /*private void HandleMoveSpeedChange(StatSO stat, float currentValue, float prevValue)
        {
            _moveSpeed = currentValue;
        }*/

        public void SetMovementDirection(Vector2 movementInput)
        {
            _movementDirection = new Vector3(movementInput.x, 0, movementInput.y).normalized;
        }

        private void FixedUpdate()
        {
            CalculateMovement();
            ApplyGravity();
            Move();
        }

        private void CalculateMovement()
        {
            if (CanManualMovement)
            {
                _velocity = Quaternion.Euler(0, -45f, 0) * _movementDirection;
                _velocity *= _moveSpeed * Time.fixedDeltaTime;
            }
            else
            {
                _velocity = _autoMovement * Time.fixedDeltaTime;
            }
        
            if (_velocity.magnitude > 0)
            {
                Quaternion targetRot = Quaternion.LookRotation(_velocity);
                float rotationSpeed = 8f;
                Transform parent = _entity.transform;
                parent.rotation = Quaternion.Lerp(parent.rotation, targetRot, Time.fixedDeltaTime * rotationSpeed);
            }
        
        }

        private void ApplyGravity()
        {
            if (IsGround && _verticalVelocity < 0)
                _verticalVelocity = -0.03f;
            else
                _verticalVelocity += gravity * Time.fixedDeltaTime;

            _velocity.y = _verticalVelocity;

        }

        private void Move()
        {
            controller.Move(_velocity);
        }

        public void StopImmediately()
        {
            _movementDirection = Vector3.zero;
        }
    
        public void SetAutoMovement(Vector3 autoMovement) => _autoMovement = autoMovement;

    
        
    }
}