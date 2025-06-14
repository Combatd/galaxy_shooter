using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
So that's where all of our logic and user input is going to go.

Now, for this, what do we want to do with our player?

This script is going to be attached to the player and behave as the player.
*/
public class Player : MonoBehaviour
{
  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {
    // Take the current position = new position (0, 0, 0)
    // A Vector3 defines all psoitions in Unity. (X, Y, Z)
    // Vector3 has a set and a get method. You are almost always going to be setting a new Vector3 object
    transform.position = new Vector3(0, 0, 0);
    
  }

  // Update is called once per frame
  void Update()
  {
    transform.Translate(new Vector3(1, 0, 0));
  }
}
