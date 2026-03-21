using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    

    public Rigidbody2D rb;

    public float speed;

    Vector2 moveInput;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        moveInput = context.ReadValue<Vector2>();
        rb.linearVelocity = moveInput * speed;
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(speed, moveInput.x);
    }
}
