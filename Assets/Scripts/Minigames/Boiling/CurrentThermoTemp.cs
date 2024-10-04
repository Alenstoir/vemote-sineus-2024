using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CurrentThermoTemp : MonoBehaviour
{
    public float boilTemp;
    public float baselineTemp;
    public float tempDropSpeed = 1f;

    private float currentTemp;
    private float coordToTemp;

    private Rigidbody rb;
    private Vector3 startPos;

    // Start is called before the first frame update
    void Start()
    {
        coordToTemp = boilTemp / (100 - baselineTemp);
        rb = GetComponent<Rigidbody>();
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionX | RigidbodyConstraints.FreezePositionZ;
        startPos = transform.position;
        currentTemp = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (currentTemp > (100 - baselineTemp)) {
            currentTemp = (100 - baselineTemp);
        }
        else if (currentTemp < 0) {
            currentTemp = 0;
        }
        Vector3 targetPos = startPos + new Vector3(0, currentTemp*coordToTemp, 0);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, Time.deltaTime);

        if (currentTemp > 0) {
            currentTemp -= tempDropSpeed * Time.deltaTime;
        }
    }

    public void BumpTemp(float temp) {
        if (currentTemp <= (100 - baselineTemp)) {
            currentTemp += temp;
        }
    }

    public float GetCurrentTemp() {
        return currentTemp + baselineTemp;
    }
}
