using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateSpinningUIScore : MonoBehaviour
{
    private GameObject gameDirector;
    private TextMeshProUGUI scoreText;
    private Score score;
    private SpinningMinigameDirector miniGameDirector;

    void Start()
    {
        gameDirector = GameObject.FindGameObjectWithTag("MinigameEventSystem");
        miniGameDirector = gameDirector.GetComponent<SpinningMinigameDirector>();
        score = gameDirector.GetComponent<Score>();
        scoreText = GetComponent<TextMeshProUGUI>();
        
    }

    void Update()
    {
        scoreText.text = $"Progress: {(int)(score.CurrentScore() / 100f)} / {(int)(miniGameDirector.churnPointsTarget / 100f)}";
    }
}
