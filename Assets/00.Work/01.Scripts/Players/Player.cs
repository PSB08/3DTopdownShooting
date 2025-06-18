using Code.Core.Dependencies;
using Code.FSM;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Code.Players
{
    public class Player : MonoBehaviour, IDependencyProvider
    {
        [field: SerializeField] public PlayerInput PlayerInput { get; private set; }

        [SerializeField] private StateDataSO[] states;

        private EntityStateMachine _stateMachine;

        [Provide]
        public Player ProvidePlayer() => this;

    }
}