using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FinishScreen : MonoBehaviour
{
    [SerializeField] private Text _text;
    [SerializeField] private Text _totalScoreText;
    [SerializeField] private Player _player;
    [SerializeField] private Knife _knife;
    [SerializeField] private List<ParticleSystem> _confetti;

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
        _totalScoreText.text.ToString();
    }

    private void ShootСonfetti()
    {
        foreach (var confetti in _confetti)
        {
            confetti.gameObject.SetActive(true);
        }
    }
}
