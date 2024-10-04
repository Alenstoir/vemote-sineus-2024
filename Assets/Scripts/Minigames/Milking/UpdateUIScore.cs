using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUIScore : MonoBehaviour
{
    private GameObject gameDirector;
    private TextMeshProUGUI scoreText;
    private Score milkScore;
    private MilkingMiniGameDirector miniGameDirector;

    void Start()
    {
        gameDirector = GameObject.FindGameObjectWithTag("MinigameEventSystem");
        miniGameDirector = gameDirector.GetComponent<MilkingMiniGameDirector>();
        milkScore = gameDirector.GetComponent<Score>();
        scoreText = GetComponent<TextMeshProUGUI>();
        
    }

    void Update()
    {
        scoreText.text = $"Score: {(int)milkScore.CurrentScore()} / {miniGameDirector.milkTarget}";
    }
}
