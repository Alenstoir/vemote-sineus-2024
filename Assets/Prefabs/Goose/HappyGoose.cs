using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HappyGoose : MonoBehaviour
{
    public GameObject goose;
    // Start is called before the first frame update
    void Update()
    {
        Animator gooseAnim = goose.GetComponentInChildren<Animator>();
        gooseAnim.SetBool("Happy", true);
    }

}
