using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.TextCore;

public class SpinningMinigameDirector : MonoBehaviour
{
    public GameObject minigame;
    public GameObject churnHandleObject;
    public float churnPointsTarget = 10000f;

    public float chumHandlePerfectSpeed = 5f;
    public float chumHandleMaxThershold = 40f;
    public float chumHandleMinThershold = 12f;
    private ChurnHandle chumHandle;
    private Score score;
    private MiniGameState gameState;
    private MiniGameDirector miniGameDirector;
    private bool state;

    void Start() {
        Initialize();
    }

    public void Initialize()
    {
        miniGameDirector = GetComponent<MiniGameDirector>();
        score = GetComponent<Score>();
        chumHandle = churnHandleObject.GetComponent<ChurnHandle>();
        gameState = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<MiniGameState>();
    }

    void FixedUpdate()
    {  
        float speed = chumHandle.GetCurrentSpeed();
        if (speed > 0) {
            if (speed >= chumHandleMaxThershold) {
                score.GainScore(Mathf.Abs(chumHandlePerfectSpeed * (speed - chumHandleMaxThershold) / (100f - chumHandleMaxThershold)));
            }
            else if (speed <= chumHandleMinThershold) {
                score.GainScore(Mathf.Abs(chumHandlePerfectSpeed * (speed) / (chumHandleMinThershold)));
            }
            else {
                score.GainScore(chumHandlePerfectSpeed);
            }
        }
    }
    public float GetCurrentSpeed() {
        return chumHandle.GetCurrentSpeed();
    }    
    public void Restart() {
        minigame.SetActive(true);
        Initialize();
        gameState.Restart();
        state = true;
    }

    public void Cleanup() {
        minigame.SetActive(false);
        state = false;
    }
}
