using System.Runtime.Serialization;
using UnityEngine;
using UnityEngine.InputSystem;

public class Test : MonoBehaviour
{
    [Header("Player Component references")]

    [SerializeField] Rigidbody2D rb;

    [SerializeField] float speed;

    public void Move(InputAction.CallbackContext context)
    {
        Vector2 input = context.ReadValue<Vector2>();
        rb.linearVelocity = input * speed;
    }
}
