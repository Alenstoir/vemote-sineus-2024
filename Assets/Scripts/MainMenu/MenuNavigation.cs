using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class MenuNavigation : MonoBehaviour
{
    public GameObject canvas;
    public VideoPlayer player;
    private bool playSceneStarter = false;
    void Start() {
        playSceneStarter = false;
        canvas.SetActive(true);
    }

    void Update() {
        if (playSceneStarter) {
            if (Input.GetKeyDown(KeyCode.Escape)) {
                player.Stop();
            }
            if (!player.isPlaying) {
                playSceneStarter = false;
                SceneManager.LoadScene(1);
            }
        }
    }

    public void Play() {
        playSceneStarter = true;
        canvas.SetActive(false);
        player.Play();
    }
    public void Quit() {
        Application.Quit();
    }
}
