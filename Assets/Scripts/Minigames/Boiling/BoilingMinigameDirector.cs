using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoilingMinigameDirector : MonoBehaviour
{
    public float tempPerClick = 2f;

    public float tempUpperLimit = 95f;
    public float tempLowerLimit = 85f;
    public float tempTimeTarget = 10f;

    public GameObject minigame;
    public GameObject thermo;

    private MiniGameDirector miniGameDirector;
    private Score score;
    private MiniGameState gameState;
    private CurrentThermoTemp currentThermoTemp;
    private bool state = false;

    
    public void Initialize() 
    {
        miniGameDirector = GetComponent<MiniGameDirector>();
        score = GetComponent<Score>();
        gameState = GetComponent<MiniGameState>();
        currentThermoTemp = thermo.GetComponent<CurrentThermoTemp>();
    }

    // Update is called once per frame
    void Update() {
        if (state) {
            if (Input.GetMouseButtonDown(0)) {
                currentThermoTemp.BumpTemp(tempPerClick);
            }
        }
    }


    void FixedUpdate()
    {
        if (state) {
            if (score.CurrentScore() >= tempTimeTarget) {
                Victory();
            }
            else {
                if (tempUpperLimit >= currentThermoTemp.GetCurrentTemp() & currentThermoTemp.GetCurrentTemp() >= tempLowerLimit) {
                    score.GainScore(Time.fixedDeltaTime);
                }
                else {
                    score.Restart();
                }
            }
        }
    }

    public void Restart() {
        minigame.SetActive(true);
        Initialize();
        gameState.Restart();
        score.Restart();
        state = true;
    }

    public void Cleanup() {
        minigame.SetActive(false);
        state = false;
    }

    public void Victory() {
        Debug.Log("Victory");
        gameState.Victory(false);
    }
}
