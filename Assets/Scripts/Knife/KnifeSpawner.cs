using System;
using UnityEngine;

public class KnifeSpawner : MonoBehaviour
{
    [SerializeField] private Knife _knife;
    [SerializeField] private Character _character;

    private bool _isSpawned = false;
    private float _currentTime;

    private void Update()
    {
        _currentTime += Time.deltaTime;

        // TrySpawnKnife(_currentTime);
    }

    private void SpawnKnife()
    {
        _knife = Instantiate(_knife);
    }

    private void TrySpawnKnife(float time)
    {
        if (!_isSpawned && time >= 0.25)
        {
            SpawnKnife();
            ChangePosition();
            _isSpawned = !_isSpawned;        
        }
    }

    private void ChangePosition()
    {
    }
}
