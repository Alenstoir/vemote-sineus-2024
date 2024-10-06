using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMiniGameDirector : AbstractGameDirector
{
    public GameObject minigame;
    public float targetScore;
    public GameObject goose;
    private Animator gooseAnim;
    private Score score;
    private MiniGameState gameState;
    private MusicDirector musicDirector;
    private GameDirector gameDirector;


    private bool state = false;
    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        Restart();
    }

    public void Initialize() {
        score = GetComponent<Score>();
        gooseAnim = goose.GetComponentInChildren<Animator>();
        gameState = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<MiniGameState>();
        musicDirector = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<MusicDirector>();
        gameDirector = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<GameDirector>();
    }


    void FixedUpdate()
    {
        if (state) {
            if (score.CurrentScore() >= targetScore) {
                Victory();
            }
        }
    }
    
    public void Victory() {
        Debug.Log("Victory");
        gameDirector.requiredOutro = true;
        gameState.Victory(false, "В главное меню");
    }

    public override void Cleanup() {
        foreach (GameObject plot in GameObject.FindGameObjectsWithTag("Plot")) {
            plot.GetComponent<Plot>().Restart();
        }
        minigame.SetActive(false);
        state = false;
    }

    public void SetupAnim() {
        gooseAnim.ResetTrigger("Idle");
        gooseAnim.ResetTrigger("Walk");
        gooseAnim.SetBool("BackSitting", false);
        gooseAnim.SetBool("LegMove", false);
        gooseAnim.SetBool("HandRotate", false);
        gooseAnim.SetBool("Kosit", true);
    }

    public override void Restart() {
        musicDirector.StartFarmingBGM();
        Initialize();
        Cleanup();
        minigame.SetActive(true);
        gameState.Restart();
        SetupAnim();
        state = true;
    }

        public override string ReturnButtonName()
    {
        return "На карту";
    }


    public override void MainMenu()
    {
        gameState.MainMenu();
        gameDirector.MoveToCity();
    }

    public override void NextLevel()
    {
        throw new System.NotImplementedException();
    }
}
