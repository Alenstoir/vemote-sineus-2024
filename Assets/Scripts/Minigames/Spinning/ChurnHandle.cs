using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChurnHandle : MonoBehaviour
{
    public float speedFactor = 1f;
    public Camera localCam;
    public GameObject chumHandle;
    private float lastAngle = 0f;
    private float speed = 0f;
    private bool mouseDrag = false;

    void Start()
    {
    }

    float AngleBetweenTwoPoints(Vector3 a, Vector3 b)
    {
        return Mathf.Atan2(b.y - a.y, b.x - a.x);
    }

    public float GetCurrentSpeed() {
        if (speed > 100) {
            return 100f;
        }
        else if (speed < 0) {
            return 0f;
        }
        return speed;
    }


    void Update() {
        if (!mouseDrag) {
            speed = 0f;
        }
    }

    void OnMouseDrag() {
        mouseDrag = true;
    }
    void OnMouseUp() {
        mouseDrag = false;
    }

    void FixedUpdate() {
        if (mouseDrag) {
            Vector3 mouseScreen = Input.mousePosition;
            Ray castPoint = localCam.ScreenPointToRay(mouseScreen);
            RaycastHit hit;
            if (Physics.Raycast(castPoint, out hit, Mathf.Infinity))
            {
                var angle = AngleBetweenTwoPoints(chumHandle.transform.position, hit.point);
                if (lastAngle == 0f) {
                    lastAngle = Mathf.Abs(angle);
                }
                speed = Mathf.Abs(lastAngle - Mathf.Abs(angle)) * speedFactor * Time.fixedDeltaTime;
                lastAngle = Mathf.Abs(angle);
                chumHandle.transform.eulerAngles = new Vector3(0f, 0f, angle * Mathf.Rad2Deg);
            }
            else {
                speed = 0f;
            }
        }
    }
}
