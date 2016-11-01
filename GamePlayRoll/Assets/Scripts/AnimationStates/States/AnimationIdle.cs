using UnityEngine;
using System.Collections;
using System;

public class AnimationIdle : AnimationState
{
  public AnimationIdle(PlayerController c) : base(c) { }

  public override string GetTriggerName()
  {
    return "idle";
  }

  public override void Manage()
  {
    if(Input.GetButton("Right" + _controller.GetPlayerID) || Input.GetButton("Left" + _controller.GetPlayerID))
    {
      _controller.ChangeState(PlayerController.AnimationStates.WALK);
      return;
    }
    
    if(Input.GetButton("Jump" + _controller.GetPlayerID))
    {
      _controller.ChangeState(PlayerController.AnimationStates.JUMP);
      return;
    }

    if (Input.GetButton("Up" + _controller.GetPlayerID) && _controller.LadderTouch)
    {
      _controller.ChangeState(PlayerController.AnimationStates.CLIMB);
      return;
    }
    
  }
}
