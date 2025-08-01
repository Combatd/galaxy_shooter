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
  [SerializeField]
  private GameObject _laserPrefab;
  [SerializeField]
  private float _fireRate = 0.5f;
  [SerializeField]
  private float _canFire = -1f;


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
    if (Input.GetKeyDown(KeyCode.Space) && Time.time > _canFire)
    {
      FireLaser();
    }
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

  void FireLaser()
  {
    // if I hit the space key
    // spawn a laser
    // The Instantiate() method creates a new instance of a prefab at a specified position and rotation.
    _canFire = Time.time + _fireRate;

    // Take cube position and set laser to y of 0.8
    Vector3 laserOrigin = new Vector3(transform.position.x, transform.position.y + 0.8f, 0);

    // Quaternion.identity means no rotation
    Instantiate(_laserPrefab, laserOrigin, Quaternion.identity);
  }
}
