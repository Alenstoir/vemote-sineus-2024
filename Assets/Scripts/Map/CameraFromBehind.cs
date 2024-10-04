using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFromBehind : MonoBehaviour
{
    public GameObject cam;
    public GameObject target;
    public int pov;
    public Vector3 relPosition = new Vector3(0, 0, 0);
    public Quaternion relRotation;
    // Start is called before the first frame update
    void Start()
    {
        relRotation = Quaternion.Euler(0f, 0f, 0f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.position = target.transform.position + relPosition;
        // transform.rotation = relRotation;
        
    }
}
