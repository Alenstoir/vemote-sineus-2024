using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TestChar : MonoBehaviour
{
    public DialogController dialogController;
    public String charName;
    public Texture2D charImage;
    private int charStage = 0;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            if (charStage == 0) {
                dialogController.InvokeDialog(charName, charStage);
            }
        }
    }
}
