using UnityEngine;
using System.Collections;

public class AnimationClimb : AnimationState
{

  public AnimationClimb(PlayerController c) : base(c) { }

  public override string GetTriggerName()
  {
    return "climb";
  }

  public override void Manage()
  {
    if (Input.GetButton("Up" + _controller.GetPlayerID) || Input.GetButton("Down" + _controller.GetPlayerID))
    {
      return;
    }

    if (Input.GetButton("Jump" + _controller.GetPlayerID))
    {
      _controller.ChangeState(PlayerController.AnimationStates.JUMP);
      return;
    }
    if (Input.GetButton("Left" + _controller.GetPlayerID) || Input.GetButton("Right" + _controller.GetPlayerID))
    {
      _controller.ChangeState(PlayerController.AnimationStates.WALK);
    }
  }

  public override void OnEnter()
  {
    _controller.Rigidbody.gravityScale = 0;
  }
  public override void OnExit()
  {
    _controller.Rigidbody.gravityScale = _controller.PlayerData.GravityScale;
  }
}
