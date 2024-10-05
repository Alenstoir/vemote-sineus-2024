using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameDirector : AbstractGameDirector
{
    private MilkingMiniGameDirector milkingMiniGameDirector;
    private BoilingMinigameDirector boilingMinigameDirector;
    private SpinningMinigameDirector spinningMinigameDirector;
    private MiniGameState miniGameState;
    private GameDirector gameDirector;

    private int gameState = 2;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        // NextLevel();
    }

    public void Initialize() {
        milkingMiniGameDirector = GetComponent<MilkingMiniGameDirector>();
        boilingMinigameDirector = GetComponent<BoilingMinigameDirector>();
        spinningMinigameDirector = GetComponent<SpinningMinigameDirector>();
        gameDirector = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<GameDirector>();
        miniGameState = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<MiniGameState>();
    }

    
    public void Update() {

    }

    public override void Restart() {
        if (gameState == 1) {
            milkingMiniGameDirector.Restart();
        }
        else if (gameState == 2) {
            boilingMinigameDirector.Restart();
        }
        else if (gameState == 3) {
            spinningMinigameDirector.Restart();
        }
    }

    public override void NextLevel() {
        if (gameState == 0) {
            gameState = 1;
        }
        else if (gameState == 1) {
            milkingMiniGameDirector.Cleanup();
            gameState = 2;
        }
        else if (gameState == 2) {
            boilingMinigameDirector.Cleanup();
            gameState = 3;
        }
        else if (gameState == 3) {
            spinningMinigameDirector.Cleanup();
            gameState = 4;
        }
        Restart();
    }

    public override void Cleanup() {
        Initialize();
        milkingMiniGameDirector.Cleanup();
        boilingMinigameDirector.Cleanup();
        spinningMinigameDirector.Cleanup();
    }

    public override void MainMenu() {
        miniGameState.MainMenu();
        gameDirector.MoveToCity();
        // SceneManager.LoadScene(0);
    }

    public override string ReturnButtonName()
    {
        return "На карту";
    }
}
