using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameDirector : MonoBehaviour
{
    public GameObject barnMinigames;
    public GameObject mainMap;
    private MiniGameState miniGameState;

    AbstractGameDirector currentMiniDirector;

    // Start is called before the first frame update
    void Awake() {
        miniGameState = GetComponent<MiniGameState>();
        // MoveToCity();
    }


    void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            miniGameState.ToggleMenu(currentMiniDirector.ReturnButtonName());
        }
    }

    public void MoveToBarn() {
        mainMap.SetActive(false);
        barnMinigames.SetActive(true);
        barnMinigames.GetComponentInChildren<MiniGameDirector>().Initialize();
        barnMinigames.GetComponentInChildren<MiniGameDirector>().Restart();
        miniGameState.Restart();
        currentMiniDirector = barnMinigames.GetComponentInChildren<MiniGameDirector>();
    }
    public void MoveToCity() {
        barnMinigames.GetComponentInChildren<MiniGameDirector>().Cleanup();
        barnMinigames.SetActive(false);
        mainMap.SetActive(true);
        miniGameState.Restart();
        currentMiniDirector = mainMap.GetComponentInChildren<MapGameDirector>();
    }

    public void Restart() {
        currentMiniDirector.Restart();
    }

    public void MainMenu() {
        currentMiniDirector.MainMenu();
    }

    public void NextLevel() {
        currentMiniDirector.NextLevel();
    }
}
