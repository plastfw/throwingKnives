using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(SphereCollider))]
[RequireComponent(typeof(FoodAnimations))]
public class Food : MonoBehaviour
{
    [SerializeField] private ParticleSystem _splash;
    [SerializeField] private ParticleSystem _point;
    
    private Slice[] _slices = new Slice[2];
    private Quaternion _zeroRotation = Quaternion.Euler(0,0,0);
    private Rigidbody _rigidbody;
    private Collider _collider;
    private int _underPath = -2;

    private void Start()
    {
        _collider = GetComponent<Collider>();
        _rigidbody = GetComponent<Rigidbody>();
        GetSlices();
    }

    private void Update()
    {
        DisableVisibility();
    }


    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Knife knife))
        {
            Cut();
        }
    }

    private void GetSlices()
    {
        for (int i = 0; i < _slices.Length; i++)
        {
            _slices[i] = transform.GetChild(i).GetComponent<Slice>();
        }
    }

    private void Cut()
    {
        gameObject.transform.rotation = _zeroRotation;
        
        _rigidbody.isKinematic = false;
        _collider.enabled = false;
        
        _splash.gameObject.SetActive(true);
        _point.gameObject.SetActive(true);

        StartCoroutine(DeactivateKinematicAndCollider());
    }
    
    private void DisableVisibility()
    {
        if (gameObject.transform.position.y <= _underPath)
        {
            gameObject.SetActive(false);
        }
    }

    private IEnumerator DeactivateKinematicAndCollider()
    {
        var halfMilliSeconds = new WaitForSeconds(0.05f);
        
        for (int i = 0; i < _slices.Length; i++)
        {
            _slices[i].SetKinematicFalse();
        }

        yield return halfMilliSeconds;
        
        for (int i = 0; i < _slices.Length; i++)
        {
            _slices[i].DeactivateCollider();
        }
        
        yield return null;
    }
}
