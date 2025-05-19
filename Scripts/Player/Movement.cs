using Unity.VisualScripting;
using UnityEngine;

public class Movement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PlayerValues values;
    private Animator animator;
    Vector2 direction = Vector2.zero;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        values = GetComponent<PlayerValues>();
    }

    // Update is called once per frame
    void Update()
    {
        direction = values.inputs.Player.Move.ReadValue<Vector2>();  // Get the movement direction
        

        // Pass information for the animation manager
        animator.SetFloat("Angle Right", Vector2.Angle(Vector2.right, rb.linearVelocity));
        animator.SetFloat("Angle Left", Vector2.Angle(Vector2.left, rb.linearVelocity));
        animator.SetFloat("Angle Back", Vector2.Angle(Vector2.down, rb.linearVelocity));
        animator.SetFloat("Angle Forward", Vector2.Angle(Vector2.up, rb.linearVelocity));
    }

    private void FixedUpdate()
    {
        rb.AddForce(direction * values.acceleration);
        rb.linearVelocity = Vector2.ClampMagnitude(rb.linearVelocity, values.maxSpeed);  // Ensure the player doesn't exceed the max speed
    }
}
