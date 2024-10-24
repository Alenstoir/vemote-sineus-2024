using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public GameObject player;
    public GameObject goose;
    public float interactDistance = 1f;

    private Animator gooseAnim;
    public float forwardSpeed = 5f;
    public float sideSpeed = 5f;
    public float backwardFactor = 1f;
    public float turnSpeed = 5f;

    private Vector3 gooseRotation;

    private Vector2 movement;
    private Rigidbody rb;
    private MiniGameState miniGameState;

    // Start is called before the first frame update
    void Start()
    {
        gooseAnim = this.transform.GetComponentInChildren<Animator>();
        rb = player.GetComponent<Rigidbody>();
        movement = new Vector3(0, 0, 0);
        rb.constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        gooseAnim.SetBool("BackSitting", false);
        gooseRotation = new Vector3(-90f, 90f, 90f);
        miniGameState = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<MiniGameState>();
    }

    // Update is called once per frame
    void Update()
    {
        float lowestDistance = float.MaxValue;
        OutlineToggle lowestDistanceInteractible = null;
        GameObject[] interactibles = GameObject.FindGameObjectsWithTag("Interactible");
        foreach (GameObject interactible in interactibles)
        {
            float interactibleDistance = (interactible.transform.position - transform.position).magnitude;
            OutlineToggle toggle = interactible.GetComponent<OutlineToggle>();
            toggle.SetOutline(false);
            if (interactibleDistance <= lowestDistance)
            {
                lowestDistance = interactibleDistance;
                lowestDistanceInteractible = toggle;
            }
        }
        if (lowestDistance <= interactDistance)
        {
            if (lowestDistanceInteractible != null)
            {
                lowestDistanceInteractible.SetOutline(true);
            }
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (miniGameState.currentState == "Playing" && Time.timeScale != 0)
                {
                    lowestDistanceInteractible.Interact();
                }
            }
        }
    }

    void FixedUpdate()
    {
        float verticalSpeed = Input.GetAxis("Vertical");
        float horizontalSpeed = Input.GetAxis("Horizontal");
        Vector3 movement = new Vector3(horizontalSpeed * forwardSpeed * Time.fixedDeltaTime, 0f, verticalSpeed * forwardSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + movement);

        Vector3 rotationVertical = Vector3.zero;
        Vector3 rotationHorizontal = Vector3.zero;
        if (verticalSpeed > 0)
        {
            rotationVertical = Vector3.down + Vector3.right * Mathf.Lerp(1, 0, Mathf.Abs(verticalSpeed));
        }
        else if (verticalSpeed < 0)
        {
            rotationVertical = Vector3.up + Vector3.right * Mathf.Lerp(1, 0, Mathf.Abs(verticalSpeed));
        }
        if (horizontalSpeed > 0)
        {
            rotationHorizontal = Vector3.right + Vector3.up * Mathf.Lerp(1, 0, Mathf.Abs(horizontalSpeed));
        }
        else if (horizontalSpeed < 0)
        {
            rotationHorizontal = Vector3.left + Vector3.up * Mathf.Lerp(1, 0, Mathf.Abs(horizontalSpeed));
        }
        if (verticalSpeed != 0 || horizontalSpeed != 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(goose.transform.forward, rotationVertical + rotationHorizontal, turnSpeed * Time.fixedDeltaTime, 0f);
            goose.transform.rotation = Quaternion.LookRotation(newDirection, Vector3.forward);
        }

        if (verticalSpeed == 0f & horizontalSpeed == 0f)
        {
            gooseAnim.ResetTrigger("Walk");
            gooseAnim.SetTrigger("Idle");
        }
        else
        {
            gooseAnim.ResetTrigger("Idle");
            gooseAnim.SetTrigger("Walk");
        }
    }

    public void MoveBackwards(float distance)
    {
        transform.Translate(transform.position + ((transform.forward * -1) * distance));
    }
}
