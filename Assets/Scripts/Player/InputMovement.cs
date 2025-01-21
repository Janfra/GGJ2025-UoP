using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class InputMovement : MonoBehaviour
{
    [SerializeField]
    private float accelerationRate;
    [SerializeField]
    private float deccelerationRate;
    [Range(0.0f, 0.99f)]
    [SerializeField]
    private float sharpTurnSpeedReduction;
    [SerializeField]
    private float maxSpeed;
    [Range(-1f, 1f)]
    [SerializeField]
    private float turnTolerance;

    [SerializeField]
    private Rigidbody2D rb;

    private float speed;
    private float decceleration;

    private Vector2 instantInput;
    private Vector2 input;
    private float xInput;
    private float yInput;

    // Start is called before the first frame update
    void Start()
    {
        if (rb == null)
        {
            rb = GetComponent<Rigidbody2D>(); 
        }
    }

    // Update is called once per frame
    void Update()
    {
        xInput = Input.GetAxis("Horizontal");
        yInput = Input.GetAxis("Vertical");
        input = new Vector2(xInput, yInput);
        instantInput = new Vector2(Input.GetAxis("Instant Horizontal"), Input.GetAxis("Instant Vertical"));

        UpdateSpeed();
        if (instantInput.sqrMagnitude > 0)
        {
            AddInputVelocity();
        }
        else
        {
            RemoveVelocity(); 
        }
    }

    private void UpdateSpeed()
    {
        if (instantInput.sqrMagnitude > 0.0f)
        {
            speed += accelerationRate * Time.deltaTime;
            speed = Mathf.Min(speed, maxSpeed);
            decceleration = deccelerationRate;
        }
        else
        {
            speed -= (deccelerationRate * deccelerationRate) * Time.deltaTime;
            decceleration += deccelerationRate * Time.deltaTime;
            speed = Mathf.Max(0.1f, speed);
        }
    }

    private void AddInputVelocity()
    {
        Vector2 velocity = rb.velocity;

        float inputDot = Vector2.Dot(velocity.normalized, instantInput.normalized);
        Vector2 inputVelocity = Vector2.zero;
        if (inputDot >= turnTolerance)
        {
            inputVelocity = input.normalized * speed;
        }
        else
        {
            speed *= sharpTurnSpeedReduction;
            inputVelocity = instantInput.normalized * speed;
        }

        velocity = inputVelocity;
        if (velocity.sqrMagnitude > maxSpeed * maxSpeed)
        {
            velocity = velocity.normalized * maxSpeed;
        }

        rb.velocity = velocity;
    }

    private void RemoveVelocity()
    {
        Vector2 velocity = rb.velocity;
        Vector2 velocityReduction = Vector2.one * decceleration;
        float xResult;
        float yResult;

        xResult = Mathf.Max(velocity.x - velocityReduction.x, 0);
        yResult = Mathf.Max(velocity.y - velocityReduction.y, 0);

        rb.velocity = new Vector2(xResult, yResult);
    }
}
