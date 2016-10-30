using UnityEngine;
using System.Collections;

public class AnimationController {

  public enum AnimationStates { IDLE, WALK, RUN, CLIMB, CLIMBIDLE, JUMP }
  private AnimationStates _actualStateEnum = AnimationStates.IDLE;
  private AnimationState _actualStateInstance;

  protected Movement _movement;
  protected Animator _animator;

  public AnimationController(Animator animator, Movement movement)
  {
    _animator = animator;
    _movement = movement;
    _actualStateInstance = BuildState(AnimationStates.IDLE);
  }

  public void ChangeState(AnimationStates state)
  {
    Debug.Log("change state to => " + state.ToString());
    if(_actualStateEnum != state)
    {
      _actualStateEnum = state;
      _actualStateInstance = BuildState(state);
      _animator.SetTrigger(_actualStateInstance.GetTriggerName());
      UpdateMovementValues();
    }
  }

  public void Update(float time)
  {
    _actualStateInstance.Manage();
  }

  public string GetPlayerID()
  {
    return _movement.PlayerID;
  }

  public bool InGround()
  {
    return _movement.InGround;
  }

  public bool InLadder()
  {
    return _movement.LadderTouch;
  }

  public void AnimationEnded()
  {
    if(_actualStateEnum == AnimationStates.CLIMB)
    {
      ChangeState(AnimationStates.CLIMBIDLE);
    }
  }

  private AnimationState BuildState(AnimationStates state)
  {
    switch(state)
    {
      case AnimationStates.IDLE: return new AnimationIdle(this);
      case AnimationStates.WALK: return new AnimationWalk(this);
      case AnimationStates.RUN: return new AnimationRun(this);
      case AnimationStates.JUMP: return new AnimationJump(this);
      case AnimationStates.CLIMBIDLE: return new AnimationClimbIdle(this);
      case AnimationStates.CLIMB: return new AnimationClimb(this);
    }
    return null;
  }

  private void UpdateMovementValues()
  {
    switch(_actualStateEnum)
    {
      case AnimationStates.IDLE: _movement.InGround = true; break;
      case AnimationStates.WALK: _movement.InGround = true; break;
      case AnimationStates.RUN: _movement.InGround = true; break;
      case AnimationStates.CLIMB: _movement.InGround = false; break;
      case AnimationStates.CLIMBIDLE: _movement.InGround = false; break;
      case AnimationStates.JUMP: _movement.InGround = false; break;
    }
  }
}
