using System;
using UnityEngine;

public class ScoreController: MonoBehaviour
{
    [SerializeField]private ScoreModel _scoreModel;

    public float GetScore()
    {
        return _scoreModel.GetScore();
    }

    public void ResetScore()
    {
        _scoreModel.ResetScore();
    }

    public void TriggerScoreUpdate()
    {
        _scoreModel.TriggerScoreUpdate();
    }

    private void Update()
    {
        if (_scoreModel.GetTrigger()) return;
        _scoreModel.AddScore(Time.deltaTime);
    }
}