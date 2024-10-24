using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Field : MonoBehaviour
{
    private GameDirector gameDirector;
    private bool collidable = true; 

    void Start() {
        gameDirector = GameObject.FindGameObjectWithTag("GlobalEventSystem").GetComponent<GameDirector>();
    }

    void OnCollisionEnter(Collision collision) {
        if (collidable) {
            collidable = false;
            if (collision.gameObject.CompareTag("Player")) {
                gameDirector.MoveToField();
            }
        }
    }

    void OnCollisionExit(Collision collision) {
        collidable = true;
    }
}
