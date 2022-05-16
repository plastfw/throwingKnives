using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
     [SerializeField] private GameObject _knifeInHand;
     [SerializeField] private bool _isActiveKnife;

     public event UnityAction Geted;
     private BoxCollider _collider;
     private Knife _currentKnife;

     private void Start()
     {
          _collider = GetComponent<BoxCollider>();
          TryThrow();
     }

     private void OnTriggerEnter(Collider collider)
     {
          if (collider.TryGetComponent(out Knife knife))
          {
               _currentKnife = knife;
               _isActiveKnife = !_isActiveKnife;
               _collider.enabled = false;
               TryThrow();
               _currentKnife.Hide();
          }
     }
     
     private void TryThrow()
     {
          if (_isActiveKnife)
          {
               ChangeRotate();
               _knifeInHand.SetActive(_isActiveKnife);
               Geted?.Invoke();
          }
     }

     private void ChangeRotate()
     {
          gameObject.transform.Rotate(0,180,0);
     }

     private void Throw()
     {
          _isActiveKnife = !_isActiveKnife;
          _knifeInHand.SetActive(_isActiveKnife);
          _currentKnife.Show(_knifeInHand.transform.position);
     }
}