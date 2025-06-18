using Code.Entities;
using UnityEngine;

namespace Code.Players.States
{
    public class PlayerAttackState : PlayerState
    {
        private PlayerAttackCompo _attackCompo;
        
        public PlayerAttackState(Entity entity, int animationHash) : base(entity, animationHash)
        {
            _attackCompo = entity.GetCompo<PlayerAttackCompo>();
        }

        public override void Enter()
        {
            base.Enter();
            _movement.CanManualMovement = false;
            Debug.Log("Attack");
        }
        
        public override void Update()
        {
            base.Update();
            if (_isTriggerCall)
            {
                _player.ChangeState("IDLE");
            }
        }
        
    }
}