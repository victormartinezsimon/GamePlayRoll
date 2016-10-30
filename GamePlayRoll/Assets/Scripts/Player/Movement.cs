using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour
{

  public string PlayerID = "P1";
  public bool _touchingGround = true;
  public bool _canLadder = false;

  private AnimationController _animationController;

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

  void Start()
  {
    _animationController = new AnimationController(GetComponent<Animator>(), this);
  }

  void Update()
  {
    _animationController.Update(Time.deltaTime);
  }

  public void AnimationEnded()
  {
    _animationController.AnimationEnded();
  }
}
