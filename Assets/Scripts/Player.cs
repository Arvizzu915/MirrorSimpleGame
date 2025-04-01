using Mirror;
using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChafo : NetworkBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject cannonBall, aim;
    [SerializeField] private float speed = 0.5f;

    private Vector2 movementInput;

    protected override void OnValidate()
    {
        base.OnValidate();
    }

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void FixedUpdate()
    {
        if (!isLocalPlayer) return;

        MovePlayer();
    }

    private void MovePlayer()
    {
        rb.AddForce(movementInput * speed, ForceMode2D.Force);
    }


    public void CallShoot(InputAction.CallbackContext context)
    {
        if (context.started)
        {
            Shoot();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Finish"))
        {
            gameObject.SetActive(false);
        }
    }

    [Command]
    private void Shoot()
    {
        Debug.Log("shoot");
        var ball = Instantiate(cannonBall, aim.transform.position, aim.transform.rotation);
        NetworkServer.Spawn(ball, connectionToClient);
        ball.GetComponent<cannonBall>().Initialize(gameObject);
    }


    public void MovementInput(InputAction.CallbackContext context)
    {

        movementInput = context.ReadValue<Vector2>().normalized;
    }
}
