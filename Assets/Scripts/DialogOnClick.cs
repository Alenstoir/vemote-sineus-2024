using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DialogOnClick : MonoBehaviour
{
    public string group;
    public int index;
    private DialogController dialogController;
    void Start() {
        dialogController = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<DialogController>();
    }
    void OnMouseUp() {
        InvokeDialog();
    }
    
    public void InvokeDialog() {
        dialogController.InvokeDialog(group, index);
    }
}
