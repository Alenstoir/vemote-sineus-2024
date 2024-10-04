using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateSpinningSpeedUi : MonoBehaviour
{
    private GameObject gameDirector;
    private TextMeshProUGUI scoreText;
    private SpinningMinigameDirector miniGameDirector;

    void Start()
    {
        gameDirector = GameObject.FindGameObjectWithTag("MinigameEventSystem");
        miniGameDirector = gameDirector.GetComponent<SpinningMinigameDirector>();
        scoreText = GetComponent<TextMeshProUGUI>();
        
    }

    void Update()
    {
        scoreText.text = $"{(int)miniGameDirector.GetCurrentSpeed()}%";
    }
}
