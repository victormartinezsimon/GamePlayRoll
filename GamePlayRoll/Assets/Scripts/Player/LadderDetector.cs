using UnityEngine;
using System.Collections;

[RequireComponent(typeof(PlayerController))]
public class LadderDetector : MonoBehaviour
{

  PlayerController _controller;

  // Use this for initialization
  void Start()
  {
    _controller = GetComponent<PlayerController>();
  }

  void OnTriggerEnter2D(Collider2D coll)
  {
    if (coll.gameObject.tag == "Ladder")
    {
      _controller.LadderTouch = true;
    }
  }
  void OnTriggerExit2D(Collider2D coll)
  {
    Debug.Log("on ladder exit");
    if (coll.gameObject.tag == "Ladder")
    {
      _controller.LadderTouch = false;
      _controller.OnLadderExit();
    }
  }
}