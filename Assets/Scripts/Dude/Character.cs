using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(BoxCollider))]
public class Character : MonoBehaviour
{
     [SerializeField] private GameObject _knifeInHand;
     [SerializeField] private bool _isActiveKnife;

     public event UnityAction Geted;
     private BoxCollider _collider;
     private Knife _currentKnife;
     private Vector3 _turn180 = new Vector3(0, 180, 0);

     private void Start()
     {
          _collider = GetComponent<BoxCollider>();
          ThrowKnife();
     }

     private void OnTriggerEnter(Collider collider)
     {
          if (collider.TryGetComponent(out Knife knife))
          {
               _currentKnife = knife;
               _isActiveKnife = !_isActiveKnife;
               _collider.enabled = false;
               ThrowKnife();
               _currentKnife.Hide();
          }
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