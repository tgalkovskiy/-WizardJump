using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    public void StartGame1()
    {
        StartGame.SwithToSin(1);
    }
    public void Restart()
    {
        StartGame.SwithToSin(SceneManager.GetActiveScene().buildIndex);
    }
    public void LoadMenu()
    {
        StartGame.SwithToSin(0);
    }
    public void Exit()
    {
        Application.Quit();
    }
}
