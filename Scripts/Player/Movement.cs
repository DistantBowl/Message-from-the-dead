using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerValues values;
    private InputSystem_Actions inputs;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        values = GetComponent<PlayerValues>();
        inputs = new InputSystem_Actions();
        inputs.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 direction = inputs.Player.Move.ReadValue<Vector2>();
        rb.AddForce(direction*values.acceleration);
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, values.maxSpeed);
    }
}
