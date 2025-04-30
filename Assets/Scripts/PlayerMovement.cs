using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerMovement : MonoBehaviour
{
    [Header("Movement Settings")]
    public float walkSpeed;
    public float runSpeed;
    public int crouchSpeed = 2;
    public float jumpForce = 4;
    public bool canSprint;
    private bool isCrouching;

    [Header("Leaning Settings")]
    public float leanAmount = 10.0f;
    public float leanSpeed = 5.0f; 
    private float _originalRotationZ; 
    private float _leanTargetRotationZ; 

    [Header("Camera Settings")]
    public float lookSpeed;
 
    [SerializeField]
    private LayerMask _groundLayerMask;

    private float lookRotation;
    private Vector2 move;
    private Rigidbody rb;
    private Camera cam;

    private Vector3 crouchHeight = new Vector3(0.5f, 0.5f, 0.5f);
    private Vector3 normalHeight = new Vector3(1, 1, 1);
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        cam = Camera.main;
        _originalRotationZ = transform.eulerAngles.z; 

        Cursor.lockState = CursorLockMode.Locked;
    }
    
    void Update()
    {
        move.x = Input.GetAxis("Horizontal");
        move.y = Input.GetAxis("Vertical");

        Debug.DrawRay(transform.position, Vector3.down * 1.1f, Color.red);

        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (Physics.Raycast(transform.position, Vector3.down, 1.1f, _groundLayerMask))
            {
                rb.AddForce(Vector2.up * jumpForce, ForceMode.Impulse);
            }
        }
        HandleCrouch();
    }
    private void HandleLean()
    {
        if (Input.GetKey(KeyCode.Q))
        {
            _leanTargetRotationZ = _originalRotationZ + leanAmount;
        }
        else if (Input.GetKey(KeyCode.E))
        {
            _leanTargetRotationZ = _originalRotationZ - leanAmount;
        }
        else
        {
            _leanTargetRotationZ = _originalRotationZ;
        }

        float newRotationZ = Mathf.LerpAngle(transform.eulerAngles.z, _leanTargetRotationZ, Time.deltaTime * leanSpeed);
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, newRotationZ);
    }

    private void HandleCrouch()
    {
        if (Input.GetKeyDown(KeyCode.LeftControl))
        {
            isCrouching = !isCrouching;
        }

        if (isCrouching)
        {
            walkSpeed = crouchSpeed;
            transform.localScale = crouchHeight;
        }
        else
        {
            walkSpeed = 2;
            transform.localScale = normalHeight;
        }
    }
    void FixedUpdate()
    {
        bool isRunning = Input.GetKey(KeyCode.LeftShift) && canSprint;
        float currentSpeed = isRunning ? runSpeed : walkSpeed;
        
        Vector3 currentVelocity = rb.velocity;
        Vector3 targetVelocity = new Vector3(move.x, 0f, move.y) * currentSpeed;

        targetVelocity = transform.TransformDirection(targetVelocity);
        Vector3 velocityChange = targetVelocity - currentVelocity;

        Vector3.ClampMagnitude(velocityChange, 0);

        rb.AddForce(new Vector3(velocityChange.x, 0, velocityChange.z),
            ForceMode.VelocityChange);
    }
    void LateUpdate()
    {
        float mouseX = Input.GetAxisRaw("Mouse X") * lookSpeed;
        float mouseY = Input.GetAxisRaw("Mouse Y") * lookSpeed;

        lookRotation = Mathf.Clamp(lookRotation - mouseY, -90, 90);
        cam.transform.localRotation = Quaternion.Euler(lookRotation, 0, 0);

        transform.rotation *= Quaternion.Euler(0, mouseX, 0);
        HandleLean();

    }
}
