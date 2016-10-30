using UnityEngine;
using System.Collections;

public class AnimationClimb : AnimationState {

  public AnimationClimb(AnimationController c) : base(c) { }

  public override string GetTriggerName()
  {
    return "climb";
  }

  public override void Manage()
  {
    if (Input.GetButton("Up" + _controller.GetPlayerID()) || Input.GetButton("Down" + _controller.GetPlayerID()))
    {
      return;
    }

    if (Input.GetButton("Jump" + _controller.GetPlayerID()))
    {
      _controller.ChangeState(AnimationController.AnimationStates.JUMP);
      return;
    }
    if (Input.GetButton("Left" + _controller.GetPlayerID()) || Input.GetButton("Right" + _controller.GetPlayerID()))
    {
      _controller.ChangeState(AnimationController.AnimationStates.WALK);
    }
  }
}
