using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class ScoreView: MonoBehaviour
{
    [SerializeField] private ScoreController _scoreController;
    [SerializeField] private TextMeshProUGUI _text;

    private void Update()
    {
        _text.text = _scoreController.GetScore().ToString("0.00");
    }
}