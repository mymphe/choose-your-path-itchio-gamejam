using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket: MonoBehaviour
{
    public static Rocket Instance { get; private set; }

    // CONSTANTS
    private const float DEFAULT_SPEED = 10f;
    private const float ACCELERATION_RATE_PARSECS = 1;
    private const float ACCELERATION_INTERVAL_SECONDS = 1f;
    private const float STRAFE_RATE = 10f;
    private const float TURN_RATE = 10f;

    // dashboard
    private float currentSpeed;
    private float accelerationTimer = 1f;
    private float distanceTraveled = 0;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        ResetSpeed();

        Hyperlane.OnHyperlaneEntered += Hyperlane_OnHyperlaneEntered;
        Hyperlane.OnHyperlaneExited += Hyperlane_OnHyperlaneExited;
    }

    private void Hyperlane_OnHyperlaneExited(object sender, EventArgs e)
    {
        ResetSpeed();
    }

    private void Hyperlane_OnHyperlaneEntered(object sender, EventArgs e)
    {
        ResetSpeed();
    }

    private void OnDestroy()
    {
        Hyperlane.OnHyperlaneEntered -= Hyperlane_OnHyperlaneEntered;
    }

    private void Update()
    {
        Move();
        Accelerate();
        UpdateDistance();
    }

    private void UpdateDistance()
    {
        distanceTraveled += Time.deltaTime * currentSpeed;
    }

    private void Move()
    {
        if (Input.GetKey(KeyCode.A))
        {
            MoveLeft();
        } else if (Input.GetKey(KeyCode.D))
        {
            MoveRight();
        } else
        {
            Straighten();
        }
    }


    public float GetSpeed()
    {
        return currentSpeed;
    }

    public float GetDistance()
    {
        return distanceTraveled;
    }

    private void MoveLeft()
    {
        transform.position += STRAFE_RATE * Time.deltaTime * new Vector3(-1f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, TURN_RATE), 0.1f);
    }

    private void MoveRight()
    {
        transform.position += STRAFE_RATE * Time.deltaTime * new Vector3(1f, 0f, 0f);
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, -TURN_RATE), 0.1f);
    }

    private void Straighten()
    {
        transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.1f);
    }

    private void ResetSpeed()
    {
        currentSpeed = DEFAULT_SPEED;
    }

    private void Accelerate()
    {
        accelerationTimer -= Time.deltaTime;
        
        if (accelerationTimer <= 0)
        {
            accelerationTimer = ACCELERATION_INTERVAL_SECONDS;
            currentSpeed += ACCELERATION_RATE_PARSECS;

            Debug.Log(currentSpeed);
        }
    }
}
