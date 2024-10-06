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
    private MusicDirector musicDirector;
    private DialogController dialogController;
    private bool tutorialPassed = false;


    void Start() {
        Initialize();
        // Restart();
    }


    public void Initialize() {
        milkEmitters = GameObject.FindGameObjectsWithTag("MilkEmitter");
        miniGameDirector = GetComponent<MiniGameDirector>();
        milkScore = GetComponent<Score>();
        gameState = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<MiniGameState>();
        musicDirector = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<MusicDirector>();

        dialogController = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<DialogController>();

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
        gameState.Defeat(miniGameDirector.ReturnButtonName());
    }

    public void Victory() {
        Debug.Log("Victory");
        gameState.Victory(true, miniGameDirector.ReturnButtonName());
    }

    public void Restart() {
        Initialize();
        musicDirector.StartMilkingBGM();
        minigame.SetActive(true);
        foreach (GameObject milkDrop in GameObject.FindGameObjectsWithTag("MilkDrop")) {
            Destroy(milkDrop);
        }
        milkTimeElapsed = 0;
        bucketController.Restart();
        gameState.Restart();
        timer.Restart();
        milkScore.Restart();
        state = true;
        if (!tutorialPassed) {
            dialogController.InvokeDialog("GooseTutor", 0);
        }
    }

    public void Cleanup() {
        foreach (GameObject milkDrop in GameObject.FindGameObjectsWithTag("MilkDrop")) {
            Destroy(milkDrop);
        }
        minigame.SetActive(false);
        state = false;
    }
}
