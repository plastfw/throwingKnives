using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private Knife _knife;
    
    private int _score = 0;
    private int _totalScore = 0;
    private int _multiplier;

    public int Score => _score;
    public int Multiplier => _multiplier;
    
    private void OnEnable()
    {
        _knife.GotPoint += AddPoint;
        _knife.PointsReseted += ResetPoints;
    }
    
    private void OnDisable()
    {
        _knife.GotPoint -= AddPoint;
        _knife.PointsReseted -= ResetPoints;
    }

    public void MultiplyPoints(int multiplier)
    {
        _multiplier = multiplier;
        _totalScore = _multiplier * _score;
    }

    private void AddPoint()
    {
        _score++;
    }

    private void ResetPoints()
    {
        _score = 0;
        _totalScore = 0;
        _multiplier = 0;
    }
}
