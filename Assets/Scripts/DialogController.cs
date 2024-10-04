using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class DialogController : MonoBehaviour
{
    
    public GameObject dialogCanvas;
    public TextMeshProUGUI dialogText;
    public TextMeshProUGUI dialogName;
    public GameObject dialogImage;

    public Texture2D defaultImage;

    private int dialogState;
    private Dictionary<string, DialogueGroup> dialogs = new Dictionary<string, DialogueGroup>();

    

    void Awake()
    {
        Dictionary<int, Dialogue> testCharGroup = new Dictionary<int, Dialogue>();
        testCharGroup.Add(0, new Dialogue("PatheticTestChar", "Hello there", "TestChar.jpg"));
        dialogs.Add("TestChar", new DialogueGroup(testCharGroup));
    }

    void Update() {
        if (dialogState != 0) {
            if (Input.GetMouseButtonDown(0)) {
                dialogState = 0;
                dialogCanvas.SetActive(false);
                Time.timeScale = 1;
            }
        }
    }

    public void InvokeDialog(string charName, int dialogStage) {
        DialogueGroup dialogueGroup;
        Dialogue dialogue;
        if (dialogs.TryGetValue(charName, out dialogueGroup)) {
            if (dialogueGroup.dialogueGroup.TryGetValue(dialogStage, out dialogue)) {
                dialogState = 1;
                Time.timeScale = 0;
                dialogCanvas.SetActive(true);
                dialogName.SetText(dialogue.charName);
                dialogText.SetText(dialogue.charText);
                dialogImage.GetComponent<Image>().material.mainTexture = defaultImage;
            }
        }
    }
}
