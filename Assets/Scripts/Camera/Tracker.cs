using UnityEngine;

public class Tracker : MonoBehaviour
{
    [SerializeField] private Transform _knife;
    [SerializeField] private float _yOffset;
    [SerializeField] private float _zOffset;
    [SerializeField] private float _xOffset;

    private void Start()
    {
        transform.position = _knife.position;
    }

    private void Update()
    {
        transform.position = new Vector3(_xOffset, _yOffset, _knife.position.z + _zOffset);
    }
}
