using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Speedometer : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI speedText;

    private void Update()
    {
        speedText.text = Rocket.Instance.GetSpeed().ToString();
    }
}
