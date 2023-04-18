using TMPro;
using UnityEngine;

public class VehicleController : MonoBehaviour
{
    private EventManager _eventManager;
    private bool _isCollided = false;
    
    [SerializeField] private TextMeshProUGUI _textTest;
    private void OnEnable()
    {
        _textTest = GameObject.FindWithTag("GameController").GetComponent<TextMeshProUGUI>();
        _textTest.text = "Iinited";
        _eventManager = FindObjectOfType<EventManager>();
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        
        if (!col.transform.CompareTag("Boundary")) return;
        // if (_isCollided) return;
        // _isCollided = true;
        _eventManager.DispatchGameOverSignal();
        _textTest.text = "GO";    
    }
    
}
