using DG.Tweening;
using UnityEngine;

public class FoodAnimations : MonoBehaviour
{
    [SerializeField] private float _yPosition;
    [SerializeField] private Vector3 _rotation;

    private float _duration = 5;
    private Tweener _yoyo;
    private Tweener _twisting;

    private void Start()
    {
        _yoyo = (transform.DOMoveY(transform.localPosition.y + _yPosition, _duration)
            .SetLoops(-1, LoopType.Yoyo).SetEase(Ease.Linear));

        _twisting = (transform.DORotate(_rotation, _duration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear));
    }
    
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Knife knife))
        {
            _yoyo.Kill();
            _twisting.Kill();
        }
    }
}
