using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    public float speed = 5f;
    public float leftBorder = 0;
    public float rightBorder = 0; 


    private Vector3 movement;
    private Rigidbody rb;

    private Vector3 startPos;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        movement = new(0, 0, 0);
        rb.constraints = RigidbodyConstraints.FreezeRotation | RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezePositionZ;
        startPos = transform.position;
    }

    void FixedUpdate()
    {
        float horizontalSpeed = Input.GetAxis("Horizontal");
        if ((transform.position.x >= leftBorder & horizontalSpeed < 0f) || (transform.position.x <= rightBorder & horizontalSpeed > 0f)) {
            movement = new(horizontalSpeed * speed * Time.fixedDeltaTime, 0, 0);
        }
        else {
            movement = new(0, 0, 0);
        }
        rb.MovePosition(rb.position + movement);
    }

    public void Restart() {
        transform.position = startPos;
    }
}
