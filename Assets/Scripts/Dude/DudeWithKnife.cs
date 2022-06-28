using System;
using UnityEngine;

[RequireComponent(typeof(BoxCollider))]
public class DudeWithKnife : MonoBehaviour
{
     [SerializeField] private GameObject _knifeInHand;
     [SerializeField] private bool _isActiveKnife;

     private BoxCollider _collider;
     private Knife _currentKnife;
     private Vector3 _turn180 = new Vector3(0, 180, 0);

     public event Action Geted;

     private void Start()
     {
          _collider = GetComponent<BoxCollider>();
          ThrowKnife();
     }

     private void OnTriggerEnter(Collider collider)
     {
          if (collider.TryGetComponent(out Knife knife))
          {
               TakeAnotherKnife(knife);
          }
     }

     private void TakeAnotherKnife(Knife knife)
     {
          _currentKnife = knife;
          _isActiveKnife = !_isActiveKnife;
          _collider.enabled = false;
          ThrowKnife();
          _currentKnife.Hide();
     }
     
     private void ThrowKnife()
     {
          if (_isActiveKnife)
          {
               TurnAround();
               _knifeInHand.SetActive(_isActiveKnife);
               Geted?.Invoke();
          }
     }

     private void TurnAround()
     {
          gameObject.transform.Rotate(_turn180);
     }

     private void Throw()
     {
          _isActiveKnife = !_isActiveKnife;
          _knifeInHand.SetActive(_isActiveKnife);
          _currentKnife.Show(_knifeInHand.transform.position);
     }
}