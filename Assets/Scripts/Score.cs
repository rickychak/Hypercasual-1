using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    
    public static Score Instance;
    private float _score = 0;
    [SerializeField] private TextMeshProUGUI _text;
    // Start is called before the first frame update
    

    public void UpdateScore()
    {
        _score += Time.deltaTime;
        _text.text = _score.ToString("0.00");
    }
    public void UploadScore()
    {
        if (_score < Controllables.Instance.highestScore) return;
        Controllables.Instance.highestScore = _score;
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
