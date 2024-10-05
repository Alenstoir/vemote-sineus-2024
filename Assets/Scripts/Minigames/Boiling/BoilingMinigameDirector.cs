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
    public GameObject goose;
    private Animator gooseAnim;

    private MiniGameDirector miniGameDirector;
    private Score score;
    private MiniGameState gameState;
    private CurrentThermoTemp currentThermoTemp;
    private DialogController dialogController;
    private bool state = false;


    void Start() {
        Initialize();
        // Restart();
    }

    
    public void Initialize() 
    {
        gooseAnim = goose.GetComponentInChildren<Animator>();
        miniGameDirector = GetComponent<MiniGameDirector>();
        score = GetComponent<Score>();
        currentThermoTemp = thermo.GetComponent<CurrentThermoTemp>();
        gameState = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<MiniGameState>();
        dialogController = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<DialogController>();
    }

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
                // else {
                //     score.Restart();
                // }
            }
        }
    }

    public void Restart() {
        minigame.SetActive(true);
        Initialize();
        gameState.Restart();
        score.Restart();
        state = true;
        SetupAnim();
    }
    
    public void SetupAnim() {
        gooseAnim.ResetTrigger("Idle");
        gooseAnim.ResetTrigger("Walk");
        gooseAnim.SetBool("BackSitting", false);
        gooseAnim.SetBool("LegMove", true);
        gooseAnim.SetBool("HandRotate", false);
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
