using DG.Tweening;
using UnityEngine;

public class TargetAnimation : MonoBehaviour
{
    [SerializeField] private Vector3[] _wayPoints;
    [SerializeField] private GameObject _footing;
    [SerializeField] private float _horizontalDuration;
    [SerializeField] private float _verticalDuration;
    [SerializeField] private float _verticalValue;
    [SerializeField] private Target _target;

    private Tween _horizontalMovement;
    private Tween _moveUp;

    private void OnEnable()
    {
        _target.TouchedTarget += KillTween;
        _target.TouchedTarget += MoveUp;
    }

    private void OnDisable()
    {
        _target.TouchedTarget -= KillTween;
        _target.TouchedTarget -= MoveUp;
    }

    private void Start()
    {
        _horizontalMovement = _footing.transform.DOLocalPath(_wayPoints, _horizontalDuration, PathType.CatmullRom)
            .SetOptions(true)
            .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear);
    }

    private void KillTween()
    {
        _horizontalMovement.Kill();
    }

    private void MoveUp()
    {
        _moveUp = gameObject.transform.DOMoveY(transform.position.y + _verticalValue, _verticalDuration);
    }
}
