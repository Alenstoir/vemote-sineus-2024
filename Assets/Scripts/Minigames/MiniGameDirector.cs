using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MiniGameDirector : MonoBehaviour
{
    private MilkingMiniGameDirector milkingMiniGameDirector;
    private BoilingMinigameDirector boilingMinigameDirector;
    private SpinningMinigameDirector spinningMinigameDirector;
    private MiniGameState miniGameState;
    private GameDirector gameDirector;

    private int gameState = 0;

    // Start is called before the first frame update
    void Start()
    {
        Initialize();
        NextLevel();
    }

    public void Initialize() {
        miniGameState = GetComponent<MiniGameState>();
        milkingMiniGameDirector = GetComponent<MilkingMiniGameDirector>();
        boilingMinigameDirector = GetComponent<BoilingMinigameDirector>();
        spinningMinigameDirector = GetComponent<SpinningMinigameDirector>();
        gameDirector = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<GameDirector>();
    }

    
    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            miniGameState.ToggleMenu();
        }
    }

    public void Restart() {
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


    public void NextLevel() {
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

    public void MainMenu() {
        miniGameState.MainMenu();
        gameDirector.MoveToCity();
        // SceneManager.LoadScene(0);
    }
}
