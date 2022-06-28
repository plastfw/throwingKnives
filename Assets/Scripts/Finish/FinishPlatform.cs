using UnityEngine;

public class FinishPlatform : MonoBehaviour
{
    [SerializeField] private Transform _start;

    public Transform Start => _start;
}