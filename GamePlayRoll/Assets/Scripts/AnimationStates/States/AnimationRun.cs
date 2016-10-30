using UnityEngine;
using System.Collections;

public class AnimationRun : AnimationState
{
  public AnimationRun(AnimationController c) : base(c) { }

  public override string GetTriggerName()
  {
    return "run";
  }

  public override void Manage()
  {
    if (!Input.GetButton("Run" + _controller.GetPlayerID()))
    {
      _controller.ChangeState(AnimationController.AnimationStates.WALK);
      return;
    }

    if (Input.GetButton("Jump" + _controller.GetPlayerID()))
    {
      _controller.ChangeState(AnimationController.AnimationStates.JUMP);
      return;
    }
    if (Input.GetButton("Left" + _controller.GetPlayerID()) || Input.GetButton("Right" + _controller.GetPlayerID()))
    {
      return;
    }
    _controller.ChangeState(AnimationController.AnimationStates.IDLE);
  }
}
