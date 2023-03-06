using UnityEngine;

public class CarMovement : MonoBehaviour
{
    private Rigidbody2D rb2;
    [SerializeField] private float speed = 20.0f;
    private void Awake()
    {
        rb2 = GetComponent<Rigidbody2D>();
    }

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        rb2.AddTorque(-speed * Time.fixedDeltaTime);
    }
}
