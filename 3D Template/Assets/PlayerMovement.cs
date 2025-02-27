using UnityEngine;
using UnityEngine.InputSystem;
[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    public float movementSpeed;

    private Rigidbody _rb; // this added to the game object preventing bugs
    private Vector3 _moveAmount;
    void Awake()
    {
        _rb = GetComponent<Rigidbody>();
    }


    void Update()
    {
        _rb.linearVelocity = new Vector3(_moveAmount.x * movementSpeed, _rb.linearVelocity.y, _moveAmount.y * movementSpeed);

        
    }
    public void HandleMovement(InputAction.CallbackContext ctx)
    {
        _moveAmount = ctx.ReadValue<Vector2>();
    }
}
