using UnityEngine;
using UnityEngine.Events;

public class Knife : MonoBehaviour
{
    [SerializeField] private GameObject _model;
    [SerializeField] private  Character _character;

    private Rigidbody _rigidbody;
    
    private void OnEnable()
    {
        _character.Throwed += Show;
    }
    
    private void OnDisable()
    {
        _character.Throwed -= Show;
    }

    private void Start()
    {
        _rigidbody = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.TryGetComponent(out Character character))
        {
            Hide();
            _character = character;
        }

        if (other.TryGetComponent(out Wall wall))
        {
            _rigidbody.isKinematic = false;
        }
    }

    private void Hide()
    {
        _model.SetActive(false);
    }

    private void Show(Vector3 position)
    {
        Debug.Log("log");
        gameObject.transform.position = position;
        _model.SetActive(true);
    }
}