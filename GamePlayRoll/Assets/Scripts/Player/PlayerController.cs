using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

  public enum AnimationStates { IDLE, WALK, RUN, CLIMB, CLIMBIDLE, JUMP }
  private AnimationStates _actualStateEnum;
  private AnimationState _actualStateInstance;

  public string _PlayerID = "P1";
  private bool _touchingGround = true;
  private bool _canLadder = false;

  private Animator _animator;
  private PlayerData _playerData;
  private Rigidbody2D _rigidbody;

  public bool InGround
  {
    get { return _touchingGround; }
    set { _touchingGround = value; }
  }
  public bool LadderTouch
  {
    get { return _canLadder; }
    set { _canLadder = value; }
  }

  public string GetPlayerID
  {
    get { return _PlayerID; }
  }

  void Start()
  {
    _animator = GetComponent<Animator>();
    _playerData = GetComponent<PlayerData>();
    _rigidbody = GetComponent<Rigidbody2D>();
    _actualStateInstance = BuildState(AnimationStates.IDLE);
  }

  void Update()
  {
    _actualStateInstance.Manage();
    AddForces();
  }

  private void AddForces()
  {
    if(_actualStateEnum == AnimationStates.JUMP)
    {
      return;
    }
    if(_actualStateEnum == AnimationStates.IDLE)
    {
      _rigidbody.
      return;
    }
    if(_actualStateEnum == AnimationStates.WALK)
    {
      if(Input.GetButton("Left" + GetPlayerID))
      {
        _rigidbody.AddForce(new Vector2(-1 ,0) * _playerData.ForceWalkX, ForceMode2D.Force);
      }
      if (Input.GetButton("Right" + GetPlayerID))
      {
        _rigidbody.AddForce(new Vector2(1, 0) * _playerData.ForceWalkX, ForceMode2D.Force);
      }
    }

    if (_actualStateEnum == AnimationStates.RUN)
    {
      if (Input.GetButton("Left" + GetPlayerID))
      {
        _rigidbody.AddForce(new Vector2(-1, 0) * _playerData.ForceRunX, ForceMode2D.Force);
      }
      if (Input.GetButton("Right" + GetPlayerID))
      {
        _rigidbody.AddForce(new Vector2(1, 0) * _playerData.ForceRunX, ForceMode2D.Force);
      }
    }

    if (_actualStateEnum == AnimationStates.CLIMB)
    {
      if (Input.GetButton("Up" + GetPlayerID))
      {
        _rigidbody.AddForce(new Vector2(0, 1) * _playerData.ForceClimbY, ForceMode2D.Force);
      }
      if (Input.GetButton("Down" + GetPlayerID))
      {
        _rigidbody.AddForce(new Vector2(0, -1) * _playerData.ForceClimbY, ForceMode2D.Force);
      }
    }

    //TODO add the rest of the forces

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
      case AnimationStates.IDLE: InGround = true; break;
      case AnimationStates.WALK: InGround = true; break;
      case AnimationStates.RUN: InGround = true; break;
      case AnimationStates.CLIMB: InGround = false; break;
      case AnimationStates.CLIMBIDLE: InGround = false; break;
      case AnimationStates.JUMP: InGround = false; break;
    }
  }
}
