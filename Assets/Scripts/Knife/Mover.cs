using System;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    private Rigidbody _rigidbody;
    private float _moveHorizontal;
    private Vector3 _movement;

    
    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MovementLogic(float value)
    {
        _moveHorizontal = value;
        _movement = new Vector3(_moveHorizontal * _horizontalSpeed, 0, 1 * _speed);

        if (transform.position.x < _maxX && transform.position.x > _minX)
        {
            _rigidbody.MovePosition(transform.position + _movement * Time.deltaTime);
        }
    }
}
