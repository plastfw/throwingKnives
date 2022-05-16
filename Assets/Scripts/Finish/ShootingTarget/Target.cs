using UnityEngine;
using UnityEngine.Events;

public class Target : MonoBehaviour
{
    [SerializeField] private int _multiplier;

    private Knife _knife;
    private Player _player;
    
    public event UnityAction TouchedTarget;
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.TryGetComponent(out Knife knife))
        {
            if (knife.transform.position.z > gameObject.transform.position.z)
            {
                return;
            }

            if (collider.TryGetComponent(out Player player))
            {
                player.MultiplyPoints(_multiplier);
            }
            _knife = knife;
            _knife.HitTarget(gameObject);
            TouchedTarget?.Invoke();
        }
    }
}
