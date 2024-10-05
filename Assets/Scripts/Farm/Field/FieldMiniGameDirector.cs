using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldMiniGameDirector : MonoBehaviour
{
    public float targetScore;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Restart() {
        foreach (GameObject plot in GameObject.FindGameObjectsWithTag("Plot")) {
            plot.GetComponent<Plot>().Restart();
        }
        GameObject player = GameObject.FindGameObjectWithTag("Player");
        player.GetComponent<FarmerControls>();
    }
}
