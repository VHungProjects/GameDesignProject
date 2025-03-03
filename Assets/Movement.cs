using UnityEngine;

public class Movement : MonoBehaviour
{

    public float speed;
    float horizontal, vertical;
    Rigidbody2D rb;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxis("Horizontal") * speed;
        vertical = Input.GetAxis("Vertical") * speed;
        rb.linearVelocity = new Vector2(horizontal, vertical);
    }
}
