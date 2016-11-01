using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour
{

  public enum AnimationStates { IDLE, WALK, CLIMB, CLIMBIDLE, JUMP }
  private AnimationStates _actualStateEnum;
  private AnimationState _actualStateInstance;

  public string _PlayerID = "P1";
  private bool _touchingGround = true;
  private bool _canLadder = false;

  private Animator _animator;
  private PlayerData _playerData;
  private Rigidbody2D _rigidbody;
  private SpriteRenderer _spriteRenderer;

  public bool jumping = true;

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
    _spriteRenderer = GetComponent<SpriteRenderer>();
    _actualStateInstance = BuildState(AnimationStates.IDLE);
  }

  void Update()
  {
    _actualStateInstance.Manage();
  }

  void FixedUpdate()
  {
    AddForces();
    Debug.Log("the force is => " + _rigidbody.velocity.x + "," + _rigidbody.velocity.y);
  }

  private void AddForces()
  {
    if(_actualStateEnum == AnimationStates.JUMP)
    {
      if(!jumping)
      {
        _rigidbody.velocity = (new Vector2(_rigidbody.velocity.x, _playerData.ForceJumpY));
        jumping = true;
      }
      return;
    }
    jumping = false;
    if (_actualStateEnum == AnimationStates.IDLE)
    {
      _rigidbody.velocity = new Vector2(0, _rigidbody.velocity.y);
      return;
    }
    if(_actualStateEnum == AnimationStates.WALK)
    {
      if(Input.GetButton("Left" + GetPlayerID))
      {
        _spriteRenderer.flipX = true;
        _rigidbody.velocity = new Vector2(-_playerData.ForceWalkX, _rigidbody.velocity.y);
      }
      if (Input.GetButton("Right" + GetPlayerID))
      {
        _spriteRenderer.flipX = false;
        _rigidbody.velocity = new Vector2(_playerData.ForceWalkX, _rigidbody.velocity.y);
      }
    }

    if (_actualStateEnum == AnimationStates.CLIMB)
    {
      if (Input.GetButton("Up" + GetPlayerID))
      {
        _rigidbody.velocity = new Vector2(0, _playerData.ForceClimbY);
      }
      if (Input.GetButton("Down" + GetPlayerID))
      {
        _rigidbody.velocity = new Vector2(0, - _playerData.ForceClimbY);
      }
    }
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
      case AnimationStates.CLIMB: InGround = false; break;
      case AnimationStates.CLIMBIDLE: InGround = false; break;
      case AnimationStates.JUMP: InGround = false; break;
    }
  }
}
