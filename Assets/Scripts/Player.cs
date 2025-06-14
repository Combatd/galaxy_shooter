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
  // public or private Reference?
  // Data type? (int, bool, float, string)
  // Every variable has a name
  // Optional value assigned
  [SerializeField]
  private float _speed = 1.5f;


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
    CalculateMovement();
  }
  
  void CalculateMovement()
  {
    float horizontalInput = Input.GetAxis("Horizontal");
    float verticalInput = Input.GetAxis("Vertical");

    Vector3 direction = new Vector3(horizontalInput, verticalInput, 0);

    transform.Translate(direction * _speed * Time.deltaTime);

    // limits for vertical axis
    // transformposition = new Vector3(transform.position.x, Mathf.Clamp(transform.position.y, -3.8f, 0), 0);
    if (transform.position.y >= 0)
    {
      transform.position = new Vector3(transform.position.x, 0, 0);
    }
    else if (transform.position.y <= -3.8f)
    {
      transform.position = new Vector3(transform.position.x, -3.8f, 0);
    }


    // limits for horizontal axis
    if (transform.position.x > 11)
    {
      transform.position = new Vector3(-11, transform.position.y, 0);
    }
    else if (transform.position.x < -11)
    {
      transform.position = new Vector3(11, transform.position.y, 0);
    }
  }
}
