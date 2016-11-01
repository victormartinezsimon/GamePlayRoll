using UnityEngine;
using System.Collections;

public class DebugCollisions : MonoBehaviour
{
  string lastCollision = "";

  void OnCollisionEnter2D(Collision2D coll)
  {
    string name = coll.gameObject.name;
    if(name != lastCollision)
    {
      Debug.Log("collision with => " + lastCollision);
      lastCollision = name;
    }
  }
}
