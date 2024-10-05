using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FarmMinigameDirector : AbstractGameDirector
{
    private FieldMiniGameDirector fieldMiniGameDirector;

    private int gameState = 0;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
    }

    void Initialize () {
        fieldMiniGameDirector = GetComponent<FieldMiniGameDirector>();
    }

    public override void Restart() {
        if (gameState == 1) {
            fieldMiniGameDirector.Restart();
        }
        else if (gameState == 2) {
        }
        else if (gameState == 3) {
        }
    }

    public override void Cleanup()
    {
        throw new System.NotImplementedException();
    }

    public override void MainMenu()
    {
        throw new System.NotImplementedException();
    }

    public override void NextLevel()
    {
        throw new System.NotImplementedException();
    }

    public override string ReturnButtonName()
    {
        throw new System.NotImplementedException();
    }
}
