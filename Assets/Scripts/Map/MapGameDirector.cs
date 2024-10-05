using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapGameDirector : AbstractGameDirector
{
    public override void Cleanup()
    {
        throw new System.NotImplementedException();
    }

    public override void MainMenu() {
        SceneManager.LoadScene(0);
    }

    public override void NextLevel()
    {
        throw new System.NotImplementedException();
    }

    public override void Restart()
    {
        throw new System.NotImplementedException();
    }

    public override string ReturnButtonName()
    {
        return "В главное меню";
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
}
