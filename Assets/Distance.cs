using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Distance : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI distanceText;

    private void Update()
    {
        distanceText.text = Mathf.FloorToInt(Rocket.Instance.GetDistance()).ToString();
    }
}
