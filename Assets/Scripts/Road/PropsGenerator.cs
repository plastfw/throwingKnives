using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PropsGenerator : MonoBehaviour
{
    [SerializeField] private List<Transform> _transforms;
    [SerializeField] private List<GameObject> _props;
    [SerializeField] private GameObject _container;

    private GameObject _prop;

    private void Start()
    {
        GenerateProps();
    }

    private void GenerateProps()
    {
        for (int i = 0; i < _transforms.Count-1; i++)
        {
            int count = Random.Range(0,_props.Count);
            
            _prop = Instantiate(_props[count]);
            _prop.transform.position = _transforms[i].position;
        }
    }
}
