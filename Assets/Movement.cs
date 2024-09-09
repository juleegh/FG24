using UnityEngine;
using UnityEngine.InputSystem;

public class Movement : MonoBehaviour
{
    [SerializeField] private Rigidbody rigidBody;
    [SerializeField] private float extraGravity;
    private InputAction moveInput;
    private InputAction jumpInput;
    private float moveSpeed = 5;
    private float jumpSpeed = 500;

    void Start()
    {
        moveInput = InputSystem.actions.FindAction("Move");
        jumpInput = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        Vector2 movement = moveInput.ReadValue<Vector2>();
        transform.Translate(Vector3.right * movement.x * moveSpeed * Time.deltaTime);
        transform.Translate(Vector3.forward * movement.y * moveSpeed * Time.deltaTime);

        if (jumpInput.triggered)
        {
            rigidBody.AddForce(Vector3.up * jumpSpeed);
        }
        rigidBody.AddForce(Vector3.down * extraGravity);
    }
}
