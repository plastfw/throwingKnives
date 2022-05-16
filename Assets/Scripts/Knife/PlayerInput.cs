using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private Mover _playerMover;
    private float _horizontalValue;
    
    private const string Horizontal = "Horizontal";

    private void Start()
    {
        _playerMover = GetComponent<Mover>();
    }

    private void FixedUpdate()
    {
        InputHorizontalMovement();
    }

    private void InputHorizontalMovement()
    {
        _horizontalValue = Input.GetAxisRaw(Horizontal);

        _playerMover.MovementLogic(_horizontalValue);
    }
}
