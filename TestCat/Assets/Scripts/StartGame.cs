using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartGame : MonoBehaviour
{
    public Image PgogresImage;
    private Animator Animator;
    private static StartGame Obj;
    private AsyncOperation LoadScene;

    private void Awake()
    {
        Animator = GetComponent<Animator>();
        Obj = this;
    }

    public static void SwithToSin(int NumberOfScene)
    {
        Debug.Log("1");
        Obj.Animator.SetTrigger("End");
        Debug.Log("2");
        Obj.LoadScene = SceneManager.LoadSceneAsync(NumberOfScene);
        Obj.LoadScene.allowSceneActivation = false;
    }
    private void Start()
    {
        Obj.Animator.SetTrigger("Start");
    }
    public void LoadNewScene()
    {
        Obj.LoadScene.allowSceneActivation = true;
    }
}
