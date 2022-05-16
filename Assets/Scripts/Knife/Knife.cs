using UnityEngine;
using UnityEngine.Events;

public class Knife : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private GameObject _trail;
    [SerializeField] private GameObject _sparks;

    private int _crashPower = 100;
    private KnifeAnimation _animation;
    private Rigidbody _rigidbody;
    private Mover _mover;
    private Collider _collider;
    private Quaternion _rotationAfterThrow = Quaternion.Euler(90, 0, 0);
    private Quaternion _rotationAfterHitTarget = Quaternion.Euler(180, 0, 180);

    public event UnityAction GotPoint;
    public event UnityAction PointsReseted;
    public event UnityAction Crashed;
    public event UnityAction HitedTarget;

    private void Start()
    {
        _animation = GetComponent<KnifeAnimation>();
        _mover = GetComponent<Mover>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Wall wall))
        {
            Crash();
            PointsReseted?.Invoke();
            _sparks.SetActive(true);
        }

        if (collider.TryGetComponent(out Food food))
        {
            GotPoint?.Invoke();
        }
    }

    public void Hide()
    {
        _collider.enabled = false;
        _trail.SetActive(false);
        _model.SetActive(false);
    }

    public void Show(Vector3 position)
    {
        _collider.enabled = true;
        _trail.SetActive(true);
        transform.position = position;
        transform.rotation = _rotationAfterThrow;
        _model.SetActive(true);
    }

    public void HitTarget(GameObject target)
    {
        transform.SetParent(target.transform);
        transform.rotation = _rotationAfterHitTarget;
        _mover.StopMoving();
        _animation.Stop();
        HitedTarget?.Invoke();
    }

    private void Crash()
    {
        _trail.SetActive(false);
        _animation.Stop();
        _collider.isTrigger = false;
        _rigidbody.useGravity = true;
        _mover.StopMoving();
        _rigidbody.AddForce(Vector3.back * _crashPower);
        Crashed?.Invoke();
    }
}