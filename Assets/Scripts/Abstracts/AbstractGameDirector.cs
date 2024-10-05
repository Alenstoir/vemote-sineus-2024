using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AbstractGameDirector : MonoBehaviour
{
    public abstract void Restart();
    public abstract void Cleanup();
    public abstract void MainMenu();
    public abstract void NextLevel();

    public abstract string ReturnButtonName();
}
