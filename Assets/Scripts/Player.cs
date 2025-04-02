using Mirror;
using System.Drawing;
using Unity.Android.Gradle;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerChafo : NetworkBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject cannonBall, aim;
    [SerializeField] private float speed = 0.5f;

    [SyncVar(hook = nameof(SetColor))]
    public UnityEngine.Color color;
    public SpriteRenderer sr;

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


    [Command]
    private void CommandSetColor(UnityEngine.Color newColor)
    {
        color = newColor;
    }


    private void SetColor(UnityEngine.Color oldColor, UnityEngine.Color newColor)
    {
        sr.color = newColor;
    }

    public void MovementInput(InputAction.CallbackContext context)
    {

        movementInput = context.ReadValue<Vector2>().normalized;
    }

    public override void OnStartClient()
    {

        CommandSetColor(GameObject.FindFirstObjectByType<PlayerInfo>().color);
        GameObject.FindWithTag("UI").gameObject.SetActive(false);
    }
}
