using System;
using Code.Core.Dependencies;
using Code.Entities;
using Code.FSM;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Players
{
    public class Player : Entity, IDependencyProvider
    {
        [field: SerializeField] public PlayerInputSO PlayerInput { get; private set; }

        [SerializeField] private StateDataSO[] states;

        private EntityStateMachine _stateMachine;

        [Provide]
        public Player ProvidePlayer() => this;

        protected override void Awake()
        {
            base.Awake();
            _stateMachine = new EntityStateMachine(this, states);
            
        }

        private void OnDestroy()
        {
            
        }

        protected override void Start()
        {
            _stateMachine.ChangeState("IDLE");
        }

        private void Update()
        {
            _stateMachine.UpdateStateMachine();
        }
        
        public void ChangeState(string newStateName) => _stateMachine.ChangeState(newStateName);
        
        
    }
}