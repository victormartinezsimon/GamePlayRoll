using UnityEngine;
using System.Collections;

public class AnimationWalk : AnimationState
{
  public AnimationWalk(PlayerController c) : base(c) { }

  public override string GetTriggerName()
  {
    return "walk";
  }

  public override void Manage()
  {
    if (Input.GetButton("Run" + _controller.GetPlayerID))
    {
      _controller.ChangeState(PlayerController.AnimationStates.RUN);
      return;
    }

    if (Input.GetButton("Jump" + _controller.GetPlayerID))
    {
      _controller.ChangeState(PlayerController.AnimationStates.JUMP);
      return;
    }
    if (Input.GetButton("Left" + _controller.GetPlayerID) || Input.GetButton("Right" + _controller.GetPlayerID))
    {
      return;
    }
      _controller.ChangeState(PlayerController.AnimationStates.IDLE);
  }
}
