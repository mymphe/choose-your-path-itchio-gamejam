using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hyperlane : MonoBehaviour
{
    public static event EventHandler OnHyperlaneEntered;
    public static event EventHandler OnHyperlaneExited;

    private bool rocketInside = false;
    private float timer;
    private float interval = 1.5f;

    private int difficulty = 1;


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Hyperlane:Collided!");

        rocketInside = true;
        OnHyperlaneEntered?.Invoke(this, EventArgs.Empty);
    }

    private void OnTriggerExit(Collider other)
    {
        Debug.Log("Hyperlane:Exited!");
        timer = 0;
        rocketInside = false;

        OnHyperlaneExited?.Invoke(this, EventArgs.Empty);
    }

    private void Update()
    {
        if (rocketInside)
        {
            timer += Time.deltaTime;

            if (timer > interval)
            {
                timer = 0;
                IncreaseDifficulty();
            }
        } else
        {
            if (difficulty > 1)
            {
                timer += Time.deltaTime;

                if (timer > interval)
                {
                    timer = 0;
                    DecreaseDifficulty();
                }
            }
        }
    }

    private void IncreaseDifficulty()
    {
        difficulty++;
        Debug.Log("Difficulty increased: " + difficulty);
    }
    
    private void DecreaseDifficulty()
    {
        difficulty--;
        Debug.Log("Difficulty decreased: " + difficulty);
    }
}
