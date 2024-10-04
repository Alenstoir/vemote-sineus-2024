using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject barnMinigames;
    public GameObject mainMap;

    // Start is called before the first frame update
    public void Update() {
    }

    public void MoveToBarn() {
        mainMap.SetActive(false);
        barnMinigames.SetActive(true);
        barnMinigames.GetComponentInChildren<MiniGameDirector>().Initialize();
        barnMinigames.GetComponentInChildren<MiniGameDirector>().Restart();
    }
    public void MoveToCity() {
        barnMinigames.SetActive(false);
        mainMap.SetActive(true);
    }
}
