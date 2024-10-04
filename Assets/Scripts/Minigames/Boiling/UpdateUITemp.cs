using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateUITemp : MonoBehaviour
{
    public GameObject thermo;
    private TextMeshPro text;
    private CurrentThermoTemp currentThermoTemp;

    void Start()
    {
        currentThermoTemp = thermo.GetComponent<CurrentThermoTemp>();
        text = this.GetComponent<TextMeshPro>();
    }

    void Update()
    {
        text.text = $"{(int)currentThermoTemp.GetCurrentTemp()}";
    }
}
