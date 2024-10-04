using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MilkingMiniGameDirector : MonoBehaviour
{
    public float milkDropTimeout = 1f;
    public int milkTarget = 5;
    public GameObject minigame;
    public GameObject bucket;

    private Score milkScore;
    private Timer timer;
    private GameObject[] milkEmitters;

    private float milkTimeElapsed = 0;
    private MiniGameState gameState;
    private bool state = false;
    private BucketController bucketController;
    private MiniGameDirector miniGameDirector;


    public void Initialize() {
        milkEmitters = GameObject.FindGameObjectsWithTag("MilkEmitter");
        miniGameDirector = GetComponent<MiniGameDirector>();
        milkScore = GetComponent<Score>();
        gameState = GetComponent<MiniGameState>();
        timer = GetComponent<Timer>();
        bucketController = bucket.GetComponent<BucketController>();
    }

    public void FixedUpdate() {
        if (state) {
            if((Time.time - milkTimeElapsed) > milkDropTimeout) {
                milkTimeElapsed = Time.time;
                if (milkEmitters.Length > 0) {
                    GameObject milkEmitter = milkEmitters[Random.Range(0, milkEmitters.Length)];
                    MilkEmitter milkEmitterScript = milkEmitter.GetComponent<MilkEmitter>();
                    milkEmitterScript.EmitMilk();
                }
            }

            if (timer.CurrentTime() == 0) {
                Defeat();
            }

            if (milkScore.CurrentScore() >= milkTarget) {
                Victory();
            }
        }
    }

    public void Defeat() {
        Debug.Log("Defeat");
        gameState.Defeat();
    }

    public void Victory() {
        Debug.Log("Victory");
        gameState.Victory(false);
    }

    public void Restart() {
        minigame.SetActive(true);
        Initialize();
        foreach (GameObject milkDrop in GameObject.FindGameObjectsWithTag("MilkDrop")) {
            Destroy(milkDrop);
        }
        milkTimeElapsed = 0;
        bucketController.Restart();
        gameState.Restart();
        timer.Restart();
        milkScore.Restart();
        state = true;
    }

    public void Cleanup() {
        minigame.SetActive(false);
        state = false;
    }
}
