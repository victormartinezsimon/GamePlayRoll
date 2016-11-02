using UnityEngine;
using System.Collections;

public abstract class AnimationState {

  public abstract string GetTriggerName();
  public abstract void Manage();

  protected PlayerController _controller;

  public AnimationState(PlayerController controller)
  {
    this._controller = controller;
  }

  public virtual void OnEnter() { }
  public virtual void OnExit() { }
}
