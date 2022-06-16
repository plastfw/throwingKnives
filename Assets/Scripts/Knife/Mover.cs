using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Mover : MonoBehaviour
{
    [SerializeField] private float _speed = 5;
    [SerializeField] private float _horizontalSpeed;
    [SerializeField] private GameObject _model;
    [SerializeField] private float _minX;
    [SerializeField] private float _maxX;

    private Rigidbody _rigidbody;
    private float _horizontal;
    private Vector3 _movementHorizontal;
    private Vector3 _movementForward;
    private float _zero = 0;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    public void MovementLogic(float value)
    {
        _horizontal = value;
        _movementHorizontal = new Vector3(_horizontal * _horizontalSpeed, 0, _speed);
        _movementForward = new Vector3(0, 0, _speed);

        if (GetRightToMove())
        {
            if (transform.position.x <= _minX && value < _zero || transform.position.x >= _maxX && value > _zero)
            {
                _rigidbody.MovePosition(transform.position + _movementForward * Time.fixedDeltaTime);
            }
            else
            {
                _rigidbody.MovePosition(transform.position + _movementHorizontal * Time.fixedDeltaTime);
            }
        }
    }

    public void StopMoving()
    {
        _speed = 0;
        _horizontalSpeed = 0;
    }
    
    private bool GetRightToMove()
    {
        if (_model.activeSelf == false)
            return false;
        
        return true;
    }
}
