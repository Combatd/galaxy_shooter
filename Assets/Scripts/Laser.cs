using UnityEngine;

public class Laser : MonoBehaviour
{
  // speed variable of 8
  private int _speed = 8;
  // time variable of 0.5
  private int _time = 15;

  // Start is called once before the first execution of Update after the MonoBehaviour is created
  void Start()
  {

  }

  // Update is called once per frame
  void Update()
  {
    // translate laser upward
    // transform.Translate(Vector3(0, 1, 0), _speed * Time.deltaTime);
    transform.Translate(Vector3.up * _speed * Time.deltaTime);

    // if the laser position is greater than 8 on the y-axis
    if (transform.position.y > 8f)
    {
      // if the parent is not null
      if (transform.parent != null)
      {
        // destroy the parent
        Destroy(transform.parent.gameObject);
      }
      // destroy the laser
      Destroy(gameObject);
    }

    destroyTime();
  }

  void destroyTime()
  {
    // destroy the laser after some time
    Destroy(gameObject, _time);
  }
}
