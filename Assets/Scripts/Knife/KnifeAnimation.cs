using DG.Tweening;
using UnityEngine;

public class KnifeAnimation : MonoBehaviour
{
    [SerializeField] private float _duration = 0.3f;

    private Vector3 _rotation = new Vector3(360, 0, 180);
    private Tweener _circleRotation;
    
    private void Start()
    {
        _circleRotation = (transform.DORotate(_rotation, _duration, RotateMode.FastBeyond360)
            .SetLoops(-1, LoopType.Restart).SetEase(Ease.Linear));
    }
}
