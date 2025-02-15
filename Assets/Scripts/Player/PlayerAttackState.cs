using UnityEngine;

public class PlayerAttackState : PlayerState
{
    public PlayerAttackState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter(){
        base.Enter();
    }
    
    public override void Exit(){
        base.Exit();
    }

    public override void Update(){
        if(triggerCalled)
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
