    using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMover : MonoBehaviour
{
    [TextArea]
    public float topSpeed;
    public float acceleration;

    private Rigidbody rigidbody;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        var input = InputSystem.actions.FindAction("Move").ReadValue<Vector2>();
        var movement = Vector2.ClampMagnitude(input, 1) * topSpeed;

        rigidbody.linearVelocity = Vector3.MoveTowards(rigidbody.linearVelocity, movement, acceleration * Time.fixedDeltaTime);
    }
}
