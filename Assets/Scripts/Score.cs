using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    public static Score Instance;
    private float _score = 0;
    [SerializeField] private TextMeshProUGUI _text;
    [SerializeField] private TextMeshProUGUI _highestScoreText;
    // Start is called before the first frame update


    public void ScoreStartSetup()
    {
        _score = 0;
        _text.text = "0.00";
        _highestScoreText.text = Controllables.Instance.highestScore.ToString("0.00");
    }
    public void UpdateScore()
    {
        _score += Time.deltaTime;
        _text.text = _score.ToString("0.00");
        
    }
    public void UploadScore()
    {
        if (_score > Controllables.Instance.highestScore)
        { 
            Controllables.Instance.highestScore = _score;
            _highestScoreText.text = _score.ToString("0.00");
        };
        _score = 0;
        _text.text = "0.00";
        
    }
    
    private void OnEnable()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(this);
        }
    }
}
