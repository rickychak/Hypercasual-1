using UnityEngine;

public class ScoreModel: MonoBehaviour
{
    private float _score = 0;
    private bool _scoreTrigger = false;


    public bool GetTrigger()
    {
        return _scoreTrigger;
    }
    
    public void TriggerScoreUpdate()
    {
        _scoreTrigger = !_scoreTrigger;
    }
    public float GetScore()
    {
        return _score;
    }
    
    public void AddScore(float score)
    {
        _score += score;
    }
}