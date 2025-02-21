using UnityEngine;

public class PlayerGroundedState : PlayerState
{
    public PlayerGroundedState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(Input.GetKey(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(player.shootState);
        }

        if(Input.GetKeyDown(KeyCode.Mouse1))
        {
            stateMachine.ChangeState(player.attackState);
        }

        if(Input.GetKeyDown(KeyCode.Space))
        {
            stateMachine.ChangeState(player.jumpState);
        }

        if(Input.GetKey(KeyCode.LeftShift) && xInput != 0)
        {
            stateMachine.ChangeState(player.runState);
        }
        else if (Input.GetKeyUp(KeyCode.LeftShift))
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
