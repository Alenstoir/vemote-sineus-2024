using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuNavigation : MonoBehaviour
{
    public void Play() {
        SceneManager.LoadScene(1);
    }
    public void Quit() {
        Application.Quit();
    }
}
