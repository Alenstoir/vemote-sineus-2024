using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MilkDrop : MonoBehaviour
{
    public int points = 1;
    private GameObject miniGameDirector;
    private Score milkScore;

    public MilkDrop(int points) {
        this.points = points;
    }

    void Start() {
        miniGameDirector = GameObject.FindGameObjectWithTag("MinigameEventSystem");
        milkScore = miniGameDirector.GetComponent<Score>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.CompareTag("Player")) {
            Destroy(gameObject);
            milkScore.GainScore(points);
        }
        else if (collision.gameObject.CompareTag("OOB")) {
            Destroy(gameObject);
        }
    }
}
