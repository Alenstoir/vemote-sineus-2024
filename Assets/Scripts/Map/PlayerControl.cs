using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject player;

    private Animator gooseAnim;
    public float forwardSpeed = 5;
    public float sideSpeed = 5;
    public float backwardFactor = 1;
    public float turnSpeed = 1;

    private Vector2 movement;
    private Rigidbody rb;
    
    // Start is called before the first frame update
    void Start()
    {
        gooseAnim = this.transform.GetComponentInChildren<Animator>();
        rb = player.GetComponent<Rigidbody>();
        movement = new Vector3(0,0,0);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        gooseAnim.SetBool("BackSitting", false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void FixedUpdate()
    {
        float verticalSpeed = Input.GetAxis("Vertical");
        Vector3 movement = transform.forward * verticalSpeed * forwardSpeed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);

        
        float horizontalSpeed = Input.GetAxis("Horizontal");
        float turn = horizontalSpeed * turnSpeed * Time.fixedDeltaTime;
        Quaternion turnRotation = Quaternion.Euler(0f, turn, 0f);
        rb.MoveRotation(rb.rotation * turnRotation);

        if (verticalSpeed == 0f & horizontalSpeed == 0f) {
            gooseAnim.ResetTrigger("Walk");
            gooseAnim.SetTrigger("Idle");
        }
        else {
            gooseAnim.ResetTrigger("Idle");
            gooseAnim.SetTrigger("Walk");
        }
    }

    public void MoveBackwards(float distance) {
        transform.Translate(transform.position + ((transform.forward * -1) * distance));
    }
}
