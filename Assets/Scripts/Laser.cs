using UnityEngine;

public class Laser : MonoBehaviour
{
  // speed variable of 8
  private int _speed = 8;
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
  }
}
