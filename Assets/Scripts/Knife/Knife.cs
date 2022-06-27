using System;
using UnityEngine;

[RequireComponent(typeof(KnifeAnimation))]
[RequireComponent(typeof(KnifeMovement))]
[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(BoxCollider))]
public class Knife : MonoBehaviour
{
    
    [SerializeField] private ParticleSystem _trail;
    [SerializeField] private ParticleSystem _sparks;
    [SerializeField] private GameObject _model;

    private KnifeAnimation _animation;
    private int _crashPower = 100;
    private Rigidbody _rigidbody;
    private KnifeMovement _knifeMovement;
    private Collider _collider;
    private Quaternion _rotationAfterThrow = Quaternion.Euler(90, 0, 0);
    private Quaternion _rotationAfterHitTarget = Quaternion.Euler(180, 0, 180);

    public event Action GotPoint;
    public event Action PointsReseted;
    public event Action Crashed;
    public event Action HitedTarget;

    private void Start()
    {
        _animation = GetComponent<KnifeAnimation>();
        _knifeMovement = GetComponent<KnifeMovement>();
        _rigidbody = GetComponent<Rigidbody>();
        _collider = GetComponent<BoxCollider>();
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Wall wall))
        {
            Crash();
            PointsReseted?.Invoke();
            _sparks.gameObject.SetActive(true);
        }

        if (collider.TryGetComponent(out Food food))
        {
            GotPoint?.Invoke();
        }
    }

    public void Hide()
    {
        _collider.enabled = false;
        _trail.gameObject.SetActive(false);
        _model.SetActive(false);
    }

    public void Show(Vector3 position)
    {
        if (position == null)
            throw new InvalidOperationException(nameof(position));
        
        _collider.enabled = true;
        _trail.gameObject.SetActive(true);
        transform.position = position;
        transform.rotation = _rotationAfterThrow;
        _model.SetActive(true);
    }

    public void HitTarget(Transform target)
    {
        if (target == null)
            throw new InvalidOperationException(nameof(target));
        
        transform.SetParent(target.transform);
        transform.rotation = _rotationAfterHitTarget;
        _knifeMovement.StopMoving();
        _animation.Stop();
        HitedTarget?.Invoke();
    }

    private void Crash()
    {
        _trail.gameObject.SetActive(false);
        _animation.Stop();
        _collider.isTrigger = false;
        _rigidbody.useGravity = true;
        _knifeMovement.StopMoving();
        _rigidbody.AddForce(Vector3.back * _crashPower);
        Crashed?.Invoke();
    }
}