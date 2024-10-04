using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{

    public string charName;
    public string charText;
    public string charImageName;

    public Dialogue(string charName, string charText, string charImageName) {
        this.charName = charName;
        this.charText = charText;
        this.charImageName = charImageName;
    }

}
