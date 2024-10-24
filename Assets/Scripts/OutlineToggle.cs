using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutlineToggle : MonoBehaviour
{
    public Color outlineColor;
    public GameObject outline;
    public GameObject interactButton;
    private Material outlineMat;
    // Start is called before the first frame update
    void Start()
    {
        outlineMat = new Material(Shader.Find("Universal Render Pipeline/Unlit"));
        outline.GetComponent<MeshRenderer>().material = outlineMat;
        outline.SetActive(false);
        interactButton.SetActive(false);
    }

    void Update()
    {
        outlineMat.color = outlineColor;
    }

    public void SetOutline(bool state)
    {
        outline.SetActive(state);
        interactButton.SetActive(state);
    }

    public void Interact()
    {
        GetComponent<DialogOnClick>().InvokeDialog();
    }
}
