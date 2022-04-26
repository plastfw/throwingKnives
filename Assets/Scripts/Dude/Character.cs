using System;
using TMPro.EditorUtilities;
using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
     [SerializeField] private GameObject _knife;
     [SerializeField] private bool _knifeInHands;

     public Transform KnifeTransform => _knife.transform;

     public event UnityAction <Vector3> Throwed;
     public event UnityAction Geted;

     private void Start()
     {
          TryThrow();
     }

     private void OnTriggerEnter(Collider collider)
     {
          if (collider.TryGetComponent(out Knife knife))
          {
               _knifeInHands = !_knifeInHands;
               TryThrow();
          }
     }
     
     private void TryThrow()
     {
          if (_knifeInHands)
          {
               ChangeRotate();
               _knife.SetActive(_knifeInHands);
               Geted?.Invoke();
          }
     }

     private void ChangeRotate()
     {
          gameObject.transform.Rotate(0,180,0);
     }

     private void Throw()
     {
          _knifeInHands = !_knifeInHands;
          _knife.SetActive(_knifeInHands);
          Throwed?.Invoke(_knife.transform.position);
     }
}