using TMPro;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float _score = 0;
    [SerializeField] private GridToWheel _grid;
    [SerializeField] private TextMeshProUGUI _text;
    // Start is called before the first frame update

    // Update is called once per frame
    void Update()
    {
        if(!UploadScore()) return;
        _score += Time.deltaTime;
        _text.text = _score.ToString("0.00");
    }


    public bool UploadScore()
    {
        if (_grid.isStarted) return _grid.isStarted;
        if (_score < Controllables.Instance.highestScore) return _grid.isStarted;
        Controllables.Instance.highestScore = _score;
        _score = 0;
        _text.text = "0.00";;
        return _grid.isStarted;

    }
}
