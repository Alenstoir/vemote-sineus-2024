using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateBoilingUIScore : MonoBehaviour
{
    private GameObject gameDirector;
    private TextMeshProUGUI scoreText;
    private Score score;
    private BoilingMinigameDirector miniGameDirector;

    void Start()
    {
        gameDirector = GameObject.FindGameObjectWithTag("MinigameEventSystem");
        miniGameDirector = gameDirector.GetComponent<BoilingMinigameDirector>();
        score = gameDirector.GetComponent<Score>();
        scoreText = GetComponent<TextMeshProUGUI>();
        
    }

    void Update()
    {
        scoreText.text = $"Boiling: {(int)score.CurrentScore()} / {miniGameDirector.tempTimeTarget}";
    }
}
