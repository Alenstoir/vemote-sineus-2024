using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueGroup
{
    public Dictionary<int, Dialogue> dialogueGroup;

    public DialogueGroup(Dictionary<int, Dialogue> dialogueGroup) {
        this.dialogueGroup = dialogueGroup;
    }

}
