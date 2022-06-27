using UnityEngine;
using Random = UnityEngine.Random;

public class Platform : MonoBehaviour
{
    [SerializeField] private Transform _endPoint;
    [SerializeField] private Transform _startPoint;
    [SerializeField] private Transform[] _fruitPoints;
    [SerializeField] private Transform[] _wallPoints;
    [SerializeField] private Wall _wall;
    [SerializeField] private Fruits[] _fruits;
    [SerializeField] private Transform _container;
    [SerializeField] private Character _character;

    public Transform EndPoint => _endPoint;
    public Transform StartPoint => _startPoint;
    
    public virtual void PutCharacter(int number)
    {
        Character character = Instantiate(_character,_container);
        character.transform.position = _wallPoints[number].transform.position;
    }

    private void Start()
    {
        GenerateWall();
        GenerateFruit();
    }

    private void GenerateWall()
    {
        int random =  Random.Range(0, _wallPoints.Length-1);

        PutCharacter(random);
        
        for (int i = 0; i < _wallPoints.Length; i++)
        {
            if (i == random)
            {
                continue;
            }
            if (random == _wallPoints.Length - 1)
            {
                break;
            }
            Wall wall = Instantiate(_wall,_container);
            wall.transform.position = _wallPoints[i].transform.position;
        }
    }
    
    private void GenerateFruit()
    {
        int random = Random.Range(0, _fruitPoints.Length);

        Fruits friuts = Instantiate(_fruits[random],_container);
        friuts.transform.position = _fruitPoints[random].transform.position;
    }
}