using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Timer : MonoBehaviour
{
    public float timer;

    private float timeLeft;

    public void Restart() {
        timeLeft = timer;
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if (timeLeft > 0) {
            timeLeft -= Time.deltaTime;
        }
        else {
            timeLeft = 0f;
        }
    }

    public float CurrentTime() {
        return timeLeft;
    }
}
