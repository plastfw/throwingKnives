using UnityEngine;

public class Slice : MonoBehaviour
{
    private Rigidbody _rigidbody;
    private Collider _collider;

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<Collider>();
    }

    public void DeactivateCollider()
    {
        _collider.enabled = false;
    }

    public void SetKinematicFalse()
    {
        _rigidbody.isKinematic = false;
    }
}
