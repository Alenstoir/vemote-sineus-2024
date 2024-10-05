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

    public Texture2D[] charImages;

    private int dialogState;
    private Dictionary<string, DialogueGroup> dialogs = new Dictionary<string, DialogueGroup>();

    

    void Awake()
    {
        Dictionary<int, Dialogue> testCharGroup = new Dictionary<int, Dialogue>();
        testCharGroup.Add(0, new Dialogue("PatheticTestChar", "Hello there", charImages[0]));
        dialogs.Add("TestChar", new DialogueGroup(testCharGroup));
        Dictionary<int, Dialogue> gooseGuideGroup = new Dictionary<int, Dialogue>();
        gooseGuideGroup.Add(0, new Dialogue(
            "Гусь-Мастер", 
            "Приветствую тебя! Чтобы собрать молоко, перемещай ведро с помощью клавиш A и D или стрелочек.", 
            charImages[0]
        ));
        gooseGuideGroup.Add(1, new Dialogue(
            "Гусь-Мастер", 
            "Теперь чтобы вскипетить молоко, нажимай на левую кнопку мыши для увеличения температуры и старайся держать температуру в нужном диапазоне.", 
            charImages[0]
        ));
        dialogs.Add("GooseGuide", new DialogueGroup(gooseGuideGroup));
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

                dialogName.transform.parent.gameObject.SetActive((dialogue.charName is null));
                dialogName.SetText(dialogue.charName);

                dialogName.transform.parent.gameObject.SetActive((dialogue.charName is null));
                dialogText.SetText(dialogue.charText);

                
                dialogName.transform.parent.gameObject.SetActive((dialogue.charName is null));
                dialogImage.GetComponent<Image>().material.mainTexture = dialogue.charImage;
            }
        }
    }
}
