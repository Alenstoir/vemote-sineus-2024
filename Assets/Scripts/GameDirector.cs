using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;

public class GameDirector : MonoBehaviour
{
    public GameObject barnMinigames;
    public GameObject fieldMap;
    public GameObject mainMap;
    private MiniGameState miniGameState;
    private MusicDirector musicDirector;
    public GameObject ui;
    public VideoPlayer outro;
    public bool requiredOutro = false;
    private bool playingOutro = false;

    AbstractGameDirector currentMiniDirector;

    // Start is called before the first frame update
    void Awake() {
        
        miniGameState = GetComponent<MiniGameState>();
        musicDirector = GetComponent<MusicDirector>();
        MoveToCity();
    }


    void Update() {
        if (playingOutro) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                outro.Stop();
            }
            if (!outro.isPlaying) {
                playingOutro = false;
                requiredOutro = false;
                ui.SetActive(true);

            }
        }
        else if (Input.GetKeyDown(KeyCode.Escape)) {
            miniGameState.ToggleMenu(currentMiniDirector.ReturnButtonName(), currentMiniDirector == mainMap);
        }

    }

    public void MoveToBarn() {
        mainMap.SetActive(false);
        fieldMap.SetActive(false);
        barnMinigames.SetActive(true);
        barnMinigames.GetComponentInChildren<MiniGameDirector>().Initialize();
        barnMinigames.GetComponentInChildren<MiniGameDirector>().Restart();
        miniGameState.Restart();
        currentMiniDirector = barnMinigames.GetComponentInChildren<MiniGameDirector>();
    }
    public void MoveToField() {
        fieldMap.SetActive(true);
        mainMap.SetActive(false);
        barnMinigames.SetActive(false);
        GameObject.FindGameObjectWithTag("MinigameEventSystem").GetComponent<FieldMiniGameDirector>().Initialize();
        currentMiniDirector = GameObject.FindGameObjectWithTag("MinigameEventSystem").GetComponent<FieldMiniGameDirector>();
        currentMiniDirector.Restart();
        miniGameState.Restart();
    }
    public void MoveToCity() {
        fieldMap.SetActive(false);
        
        if (barnMinigames.activeInHierarchy) {
            barnMinigames.GetComponentInChildren<MiniGameDirector>().Cleanup();
            barnMinigames.SetActive(false);
        }
        musicDirector.StartMainBGM();
        mainMap.SetActive(true);
        miniGameState.Restart();
        currentMiniDirector = mainMap.GetComponentInChildren<MapGameDirector>();
        if (requiredOutro) {
            playingOutro = true;
            ui.SetActive(false);
            outro.Play();
        }
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

    public void Options() {
        miniGameState.ToggleOptions();
    }
}
