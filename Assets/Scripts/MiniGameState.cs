using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MiniGameState : MonoBehaviour
{
    public GameObject bgPlane;
    public GameObject optionsPlane;
    public GameObject pausePlane;
    public GameObject errorPlane;
    public GameObject menuPlane;
    public GameObject loosePlane;
    public GameObject winPlane;
    public string currentState;
    private float lastTimeScale;
    public string lastState;

    void Start()
    {
        errorPlane.SetActive(false);
        bgPlane.SetActive(false);
        currentState = "Playing";
        lastTimeScale = Time.timeScale;
    }

    public void Defeat(string returnButtonName = "В главное меню"){
        lastState = currentState;
        currentState = "Defeat";
        lastTimeScale = Time.timeScale;
        Time.timeScale = 0;

        for (int i = 0; i < loosePlane.transform.GetChild(1).childCount; i += 1) {
            GameObject child = loosePlane.transform.GetChild(1).GetChild(i).gameObject;
            if (child.name == "MainMenuButton") {
                child.GetComponentInChildren<TextMeshProUGUI>().SetText(returnButtonName);
            }
        }
        loosePlane.SetActive(true);
        bgPlane.SetActive(true);
    }

    public void Victory(bool hasNextLevel=true, string returnButtonName = "В главное меню") {
        lastState = currentState;
        currentState = "Victory";
        lastTimeScale = Time.timeScale;
        Time.timeScale = 0;
        for (int i = 0; i < winPlane.transform.GetChild(1).childCount; i += 1) {
            GameObject child = winPlane.transform.GetChild(1).GetChild(i).gameObject;
            if (child.name == "NextLevel") {
                child.SetActive(hasNextLevel);
            }
        }
        for (int i = 0; i < winPlane.transform.GetChild(1).childCount; i += 1) {
            GameObject child = winPlane.transform.GetChild(1).GetChild(i).gameObject;
            if (child.name == "MainMenuButton") {
                child.GetComponentInChildren<TextMeshProUGUI>().SetText(returnButtonName);
            }
        }
        winPlane.SetActive(true);
        bgPlane.SetActive(true);
    }

    public void MainMenu() {
        currentState = "MainMenu";
        Time.timeScale = 1;
        pausePlane.SetActive(false);
        errorPlane.SetActive(false);
        menuPlane.SetActive(false);
        loosePlane.SetActive(false);
        winPlane.SetActive(false);
        bgPlane.SetActive(false);
    }

    public void Restart(){
        pausePlane.SetActive(false);
        errorPlane.SetActive(false);
        menuPlane.SetActive(false);
        loosePlane.SetActive(false);
        winPlane.SetActive(false);
        bgPlane.SetActive(false);
        currentState = "Playing";
        Time.timeScale = 1;
    }

    public void Pause(){
        pausePlane.SetActive(true);
        bgPlane.SetActive(true);
        lastState = currentState;
        currentState = "Paused";
        lastTimeScale = Time.timeScale;
        Time.timeScale = 0;
    }

    public void Resume(){
        pausePlane.SetActive(false);
        bgPlane.SetActive(false);
        currentState = lastState;
        Time.timeScale = lastTimeScale;
    }

    public void Error() {
        lastState = currentState;
        currentState = "Error";
        lastTimeScale = Time.timeScale;
        Time.timeScale = 0;
        errorPlane.SetActive(true);
        bgPlane.SetActive(true);
    }

    public void ToggleMenu(string returnButtonName = "В главное меню", bool hideRestart = false) {
        if (currentState == "Menu") {
            if (lastState == "Paused") {
                pausePlane.SetActive(true);
                bgPlane.SetActive(true);
            }
            currentState = lastState;
            Time.timeScale = lastTimeScale;
            menuPlane.SetActive(false);
            bgPlane.SetActive(false);
        }
        else {
            if (new List<string> {"Playing", "Paused"}.Contains(currentState)) {
                for (int i = 0; i < menuPlane.transform.GetChild(1).childCount; i += 1) {
                    GameObject child = menuPlane.transform.GetChild(1).GetChild(i).gameObject;
                    if (child.name == "MainMenuButton") {
                        child.GetComponentInChildren<TextMeshProUGUI>().SetText(returnButtonName);
                    }
                }
                for (int i = 0; i < menuPlane.transform.GetChild(0).childCount; i += 1) {
                    GameObject child = menuPlane.transform.GetChild(1).GetChild(i).gameObject;
                    if (child.name == "RestartButton") {
                        child.SetActive(hideRestart);
                    }
                }
                lastState = currentState;
                currentState = "Menu";
                lastTimeScale = Time.timeScale;
                Time.timeScale = 0;
                menuPlane.SetActive(true);
                bgPlane.SetActive(true);

            }
        }
    }

    public void TogglePause() {
        if (currentState == "Paused" ) {
            Resume();
        }
        else if (currentState == "Playing") {
            Pause();
        }
        else {
            Debug.Log($"Unable to toggle pause on state {currentState}");
        }
    }

    public void ToggleOptions() {
        if (currentState == "Menu" ) {
            menuPlane.SetActive(false);
            optionsPlane.SetActive(true);
            currentState = "Options";
        }
        else if (currentState == "Options") {
            menuPlane.SetActive(true);
            optionsPlane.SetActive(false);
            currentState = "Menu";
        }
        else {
            Debug.Log($"Unable to toggle options on state {currentState}");
        }
    }
}
