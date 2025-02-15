using UnityEngine;

public class PlayerRunState : PlayerGroundedState
{
    public PlayerRunState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {

    }

    public override void Enter()
    {
        base.Enter();

        player.SetZeroVelocity();
    }
    
    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        player.SetVelocity(xInput * player.moveSpeed * 1.5f, rb.linearVelocity.y);

        // if(xInput != 0)
        // {
        //     stateMachine.ChangeState(player.walkState);
        // }
    }
}
