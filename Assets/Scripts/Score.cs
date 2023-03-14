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
        if(!ScoreReset()) return;
        _score += Time.deltaTime;
        _text.text = _score.ToString("0.00");
    }

    public bool ScoreReset()
    {
        if (_grid.isStarted) return _grid.isStarted;
            
        _score = 0;
        _text.text = "0.00";;
        return _grid.isStarted;
    }
}
