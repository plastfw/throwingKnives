using UnityEngine;
using System.Collections.Generic;
using System.Linq;

public class MapGenerator : MonoBehaviour
{
    [SerializeField] private Platform _firstPlatform;
    [SerializeField] private Platform _platform;
    [SerializeField] private FinishPlatform _finish;
    [Space(30)]
    [SerializeField] private Character _character;
    [SerializeField] private GameObject _pool;
    [Range(2,10)][SerializeField] private int _lenght;
    [SerializeField] private Vector3 _firstCharacterPositions;
    
    private List<Platform> _poolPlatforms = new List<Platform>();
    private Platform _lastSpawned;
    private Platform _first;

    private void Start()
    {
        CreatePool();
        CreateFirstPlatform();
        MakeRoad();
        PutCharacter();
        CreateFinish();
    }
    
    private void CreatePool()
    {
        for (int i = 0; i < _lenght; i++)
        {
            Platform spawned = Instantiate(_platform, _pool.transform);
            spawned.gameObject.SetActive(false);
            _poolPlatforms.Add(spawned);
        }
    }

    private void MakeRoad()
    {
        for (int i = 0; i < _lenght-1; i++)
        {
            if (TryGetPlatform(out Platform platform))
            {
                platform.transform.position = Vector3.zero;
                platform.transform.position = _lastSpawned.EndPoint.position-platform.StartPoint.position;
                platform.gameObject.SetActive(true);
                _lastSpawned = platform;
            }
        }
    }

    private bool TryGetPlatform(out Platform result)
    {
        result = _poolPlatforms.FirstOrDefault(p => p.gameObject.activeSelf == false);
        return result != null;
    }

    private void CreateFirstPlatform()
    {
        _first = _firstPlatform;
        Instantiate(_first, _pool.transform.position, Quaternion.identity, _pool.transform);
        _lastSpawned = _first;
    }

    private void CreateFinish()
    {
        FinishPlatform finish = Instantiate(_finish,_pool.transform);
        finish.transform.position = Vector3.zero;
        finish.transform.position = _lastSpawned.EndPoint.position - finish.Start.position;
    }

    private void PutCharacter()
    {
        Character character = Instantiate(_character);
        character.transform.position = _firstCharacterPositions;
    }
}
