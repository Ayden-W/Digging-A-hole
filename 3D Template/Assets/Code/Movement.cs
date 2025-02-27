using UnityEngine;

public class Movement : MonoBehaviour
{
    private Vector3 moveInput;
    private float activeMoveSpeed;
    public float moveSpeed;
    public Rigidbody rb3D;
    float xInput;
    float yInput;
    float zInput;

    // Start is called once before the first execution of Update after the MonoBehaviour is createdw
    void Start()
    {
        rb3D = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
       
        rb3D.linearVelocity = moveInput * activeMoveSpeed;
    }

    private void FixedUpdate()
    {
        rb3D.AddForce(xInput * moveSpeed, 0, yInput * moveSpeed);
    }
}
