using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class GroundDetector : MonoBehaviour
{
  PlayerController _controller;

  // Use this for initialization
  void Start()
  {
    _controller = GetComponent<PlayerController>();
  }

  void OnCollisionEnter2D(Collision2D coll)
  {
    if(_controller.InGround)
    {
      return;
    }

    if(coll.gameObject.tag == "Ground")
    {
      _controller.InGround = true;
    }

  }
}
