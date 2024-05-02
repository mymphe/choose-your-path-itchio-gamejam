using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestructionZone : MonoBehaviour
{
    private int obstacleLayer = 7;  

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer == obstacleLayer)
        {
            Destroy(other.gameObject);
        }
    }
}
