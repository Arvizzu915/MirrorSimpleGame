using UnityEngine;
using UnityEngine.InputSystem;

public class Aiming : MonoBehaviour
{
    private Camera mainCamera;

    void Start()
    {
        mainCamera = Camera.main; // Get the main camera
    }

    void Update()
    {
        Vector2 mousePosition = Mouse.current.position.ReadValue(); // Get mouse position in screen space
        Vector2 worldMousePos = mainCamera.ScreenToWorldPoint(mousePosition); // Convert to world position

        Vector2 direction = (worldMousePos - (Vector2)transform.position).normalized; // Direction to mouse
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg; // Convert to angle
        transform.rotation = Quaternion.Euler(0, 0, angle); // Apply rotation
    }
}
