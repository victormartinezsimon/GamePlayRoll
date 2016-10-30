using UnityEngine;
using System.Collections;

public abstract class AnimationState {

  public abstract string GetTriggerName();
  public abstract void Manage();

  protected AnimationController _controller;

  public AnimationState(AnimationController controller)
  {
    this._controller = controller;
  }
}
