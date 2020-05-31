using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Ingame_Manager : MonoBehaviour
{
    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public void Restart_Game()
    {
        Scene_Manager_Script.instance.Restart_Game();
    }

    public void Go_Home()
    {
        Scene_Manager_Script.instance.Go_Home();
    }

    public void Pause()
    {
        
    }
}
