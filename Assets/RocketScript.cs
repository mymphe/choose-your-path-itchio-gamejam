using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketScript : MonoBehaviour
{
    public static RocketScript Instance { get; private set; }

    public float distanceTraveled = 0;

    private float currentSpeed = 20f;

    private float strafeSpeed = 10f;
    private float rotateSpeed = 10f;

    private const float defaultSpeed = 20f;
    private const float leftHyperlaneThreshold = -2f;
    private const float leftHyperlaneSpeed = 30f;
    private const float rightHyperlaneThreshold = 2f;
    private const float rightHyperlaneSpeed = 10f;

    private void Awake()
    {
        Instance = this;
    }

    private void Update()
    {
        Move();
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
            transform.position +=  Time.deltaTime * new Vector3(-strafeSpeed, 0f, 0f);

            if (transform.position.x < leftHyperlaneThreshold) 
            {
                currentSpeed = leftHyperlaneSpeed;
            } 

            // change rotation
            float newZRotation = 1f * rotateSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, newZRotation), 0.1f);
        } else if (Input.GetKey(KeyCode.D))
        {
            transform.position +=  Time.deltaTime * new Vector3(strafeSpeed, 0f, 0f);

            if (transform.position.x > rightHyperlaneThreshold)
            {
                currentSpeed = rightHyperlaneSpeed;
            } 

            // change rotation
            float newZRotation = -1f * rotateSpeed;
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, newZRotation), 0.1f);
        } else
        {
            transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(0, 0, 0), 0.1f);
        }


        if (transform.position.x > leftHyperlaneThreshold && transform.position.x < rightHyperlaneThreshold)
        {
            currentSpeed = defaultSpeed;
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

}
