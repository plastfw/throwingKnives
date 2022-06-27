using UnityEngine;

public class PlayerInput : MonoBehaviour
{
    private KnifeMovement _playerKnifeMovement;
    private float _horizontalValue;
    
    private const string Horizontal = "Horizontal";

    private void Start()
    {
        _playerKnifeMovement = GetComponent<KnifeMovement>();
    }

    private void FixedUpdate()
    {
        InputHorizontalMovement();
    }

    private void InputHorizontalMovement()
    {
        _horizontalValue = Input.GetAxisRaw(Horizontal);

        _playerKnifeMovement.MovementLogic(_horizontalValue);
    }
}
