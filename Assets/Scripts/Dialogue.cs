using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue
{

    public string charName;
    public string charText;
    public Texture2D charImage;

    public Dialogue(string charName, string charText, Texture2D charImage) {
        this.charName = charName;
        this.charText = charText;
        this.charImage = charImage;
    }

}
