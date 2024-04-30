using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speedText;
    [SerializeField] private TextMeshProUGUI distanceText;

    private void Update()
    {
        speedText.text = RocketScript.Instance.GetSpeed().ToString();
        distanceText.text = Mathf.FloorToInt(RocketScript.Instance.GetDistance()).ToString() + " parsecs";
    }
}
