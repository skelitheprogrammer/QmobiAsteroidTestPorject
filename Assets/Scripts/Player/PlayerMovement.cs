using UnityEngine;

public sealed class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _acceleration = 24f;
    [SerializeField] private float _accelerationForce = 6f;
    [SerializeField] private float _rotationSpeed = 120f;
    [SerializeField] private float _maxSpeed = 2f;
    
    private Rigidbody2D _rb;
    private PlayerInput _input;

    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        _input = GetComponent<PlayerInput>();
    }

    private void Update()
    {
        //Not the best solution

        if (Input.GetKey(_input.KeycodeMove))
        {
            Move();
        }

        if (Input.GetKey(_input.KeycodeRotateLeft))
        {
            Rotate(-1);
        }

        if (Input.GetKey(_input.KeycodeRotateRight))
        {
            Rotate(1);
        }

    }

    private void FixedUpdate()
    {
        if (_rb.velocity.magnitude > _maxSpeed)
        {
            _rb.velocity = _rb.velocity.normalized * _maxSpeed;
        }

    }

    private void Move()
    {
        _rb.AddForce(_acceleration * _accelerationForce * Time.deltaTime * transform.up, ForceMode2D.Force);
    }

    private void Rotate(float amount)
    {
        Vector3 newRotation = transform.eulerAngles;
        newRotation += new Vector3(0, 0, -amount * _rotationSpeed * Time.deltaTime);

        transform.eulerAngles = newRotation;
    }
}
