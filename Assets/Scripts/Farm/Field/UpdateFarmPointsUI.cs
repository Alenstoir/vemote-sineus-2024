using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpdateFarmPointsUI : MonoBehaviour
{
    
    private GameObject gameDirector;
    private TextMeshProUGUI scoreText;
    private Score score;
    private FieldMiniGameDirector fieldMiniGameDirector;
    // Start is called before the first frame update
    void Start()
    {
        gameDirector = GameObject.FindGameObjectWithTag("MinigameEventSystem");
        score = gameDirector.GetComponent<Score>();
        fieldMiniGameDirector = gameDirector.GetComponent<FieldMiniGameDirector>();
        scoreText = GetComponent<TextMeshProUGUI>();
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = $"{(int)score.CurrentScore()} / {(int)fieldMiniGameDirector.targetScore}";
    }
}
