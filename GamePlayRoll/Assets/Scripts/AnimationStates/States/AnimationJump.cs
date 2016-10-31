using UnityEngine;
using System.Collections;

public class AnimationJump : AnimationState {

  public AnimationJump(PlayerController c) : base(c) { }

  public override string GetTriggerName()
  {
    return "jump";
  }

  public override void Manage()
  {
    if(_controller.InGround)
    {
      _controller.ChangeState(PlayerController.AnimationStates.IDLE);
    }
  }
}
