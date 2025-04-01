using UnityEngine;
using Mirror;
using UnityEngine.InputSystem;

public class Player : NetworkBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private Rigidbody2D rb;

    private Vector2 movementInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isOwned)
        {
            Movement();
        }
    }

    private void Movement()
    {
        rb.linearVelocity = new Vector2(0, movementInput.y * speed);
    }

    public void MovementInput(InputAction.CallbackContext context)
    {
        movementInput = context.ReadValue<Vector2>().normalized;
    }

}
