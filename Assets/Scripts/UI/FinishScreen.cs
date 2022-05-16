using System;
using UnityEngine;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _totalScoreText;
    [SerializeField] private Player _player;
    [SerializeField] private Knife _knife;
    [SerializeField] private GameObject _confetti;

    private int _totalScore;

    private void Start()
    {
        SetText(_player.Score,_player.Multiplier);
        SetTotalText();
        ShootСonfetti();
    }

    private void SetText(int score, int multiplier)
    {
        _totalScore = score * multiplier;
        
        _text.text = score + " Fruits Cut x" + multiplier;
    }

    private void SetTotalText()
    {
        _totalScoreText.text = Convert.ToString(_totalScore);
    }

    private void ShootСonfetti()
    {
        _confetti.SetActive(true);
    }
}
