using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateUITimer : MonoBehaviour
{
    private GameObject gameDirector;
    private TextMeshProUGUI scoreText;
    private Timer timer;

    void Start()
    {
        gameDirector = GameObject.FindGameObjectWithTag("MinigameEventSystem");

        timer = gameDirector.GetComponent<Timer>();
        scoreText = GetComponent<TextMeshProUGUI>();
        
    }

    void Update()
    {
        scoreText.text = $"Time: {(int)timer.CurrentTime()}";
    }
}
