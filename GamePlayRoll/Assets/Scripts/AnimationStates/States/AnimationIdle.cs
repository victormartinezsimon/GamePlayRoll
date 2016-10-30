using UnityEngine;
using System.Collections;
using System;

public class AnimationIdle : AnimationState
{
  public AnimationIdle(AnimationController c) : base(c) { }

  public override string GetTriggerName()
  {
    return "idle";
  }

  public override void Manage()
  {
    if(Input.GetButton("Right" + _controller.GetPlayerID()) || Input.GetButton("Left" + _controller.GetPlayerID()))
    {
      if(Input.GetButton("Run" + _controller.GetPlayerID()))
      {
        _controller.ChangeState(AnimationController.AnimationStates.RUN);
      }
      else
      {
        _controller.ChangeState(AnimationController.AnimationStates.WALK);
      }
      return;
    }
    
    if(Input.GetButton("Jump" + _controller.GetPlayerID()))
    {
      _controller.ChangeState(AnimationController.AnimationStates.JUMP);
      return;
    }

    if (Input.GetButton("Up" + _controller.GetPlayerID()) && _controller.InLadder())
    {
      _controller.ChangeState(AnimationController.AnimationStates.CLIMB);
      return;
    }
    
  }
}
