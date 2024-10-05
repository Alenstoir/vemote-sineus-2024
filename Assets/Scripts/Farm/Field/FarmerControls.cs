using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmerControls : MonoBehaviour
{
    public float forwardSpeed = 5;
    public float sideSpeed = 5;
    public float backwardFactor = 1;
    public float turnSpeed = 1;

    private Vector2 movement;
    private Vector3 startPos;
    private Rigidbody rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = this.GetComponent<Rigidbody>();
        movement = new Vector3(0,0,0);
        startPos = transform.position;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationY | RigidbodyConstraints.FreezePositionZ;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float verticalSpeed = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalSpeed * forwardSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        
        float horizontalSpeed = Input.GetAxis("Horizontal");
        float turn = horizontalSpeed * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.Space)) {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, transform.up * -1, out hit, Mathf.Infinity)) {
                if (hit.transform.tag == "Plot") {
                    hit.transform.GetComponent<Plot>().PlotInteract();
                }
            }
        }
    }

    public void Restart() {
        transform.position = startPos;
    }
}
