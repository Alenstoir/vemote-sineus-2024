using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private float score = 0;

    public void GainScore(float addedScore) {
        score += addedScore;
    }

    public float CurrentScore() {
        return score;
    }

    public void Restart() {
        score = 0f;
    }
}
