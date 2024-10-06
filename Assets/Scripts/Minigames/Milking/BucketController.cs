using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BucketController : MonoBehaviour
{
    public float speed = 5f;
    public float leftBorder = 0;
    public float rightBorder = 0; 

    public GameObject goose;
    private Animator gooseAnim;
    private Vector3 movement;
    private Rigidbody rb;

    private Vector3 startPos;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        gooseAnim = goose.GetComponentInChildren<Animator>();
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
        SetupAnim();
    }

    public void SetupAnim() {
        gooseAnim.ResetTrigger("Idle");
        gooseAnim.ResetTrigger("Walk");
        gooseAnim.SetBool("LegMove", false);
        gooseAnim.SetBool("HandRotate", false);
        gooseAnim.SetBool("BackSitting", true);
        gooseAnim.SetBool("Kosit", false);
    }
}
