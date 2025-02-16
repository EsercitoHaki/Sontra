using UnityEngine;

public class PlayerShotState : PlayerState
{
    public PlayerShotState(Player _player, PlayerStateMachine _stateMachine, string _animBoolName) : base(_player, _stateMachine, _animBoolName)
    {
    }

    public override void Enter(){
        base.Enter();
    }
    
    public override void Exit(){
        base.Exit();
    }

    public override void Update(){
        base.Update();

        // if(triggerCalled)
        // {
        //     stateMachine.ChangeState(player.idleState);
        // }

        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            stateMachine.ChangeState(player.idleState);
        }
    }
}
