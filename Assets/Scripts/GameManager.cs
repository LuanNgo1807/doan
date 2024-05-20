using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager _instance;
    public GamePlay gamePlay;
    private void Awake()
    {
        //if (_instance != null && _instance != this)
        //{
        //    Destroy(this);
        //    return;
        //}
        //else
        //{
            _instance = this;
      //  }
      //  DontDestroyOnLoad(this);
    }
    private void Start()
    {
        GameState.stateGame = StateGame.Playing;
    }

    //private void Update()
    //{
    //    if (Input.GetKeyDown("u"))
    //    {
    //        Cursor.lockState = CursorLockMode.None;
    //        Cursor.visible = true;
    //        SceneManager.LoadScene(0);
    //    }
    //}
}
