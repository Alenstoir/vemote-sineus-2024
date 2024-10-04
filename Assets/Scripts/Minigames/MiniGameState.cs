using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MiniGameState : MonoBehaviour
{
    public GameObject bgPlane;
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

    public void Defeat(){
        lastState = currentState;
        currentState = "Defeat";
        lastTimeScale = Time.timeScale;
        Time.timeScale = 0;
        loosePlane.SetActive(true);
        bgPlane.SetActive(true);
    }

    public void Victory(bool hasNextLevel=true) {
        lastState = currentState;
        currentState = "Victory";
        lastTimeScale = Time.timeScale;
        Time.timeScale = 0;
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

    public void ToggleMenu() {
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
}
