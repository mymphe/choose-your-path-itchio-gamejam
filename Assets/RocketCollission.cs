using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketCollission : MonoBehaviour
{

    private void Start()
    {
        Hyperlane.OnHyperlaneEntered += Hyperlane_OnHyperlaneEntered;
    }

    private void Hyperlane_OnHyperlaneEntered(object sender, System.EventArgs e)
    {
        Debug.Log("Rocket:Collided!");
    }
}
