﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour{

public GameObject PauseMenu, PauseButton;

public void Paused(){

    Time.timeScale=0;
    PauseMenu.SetActive(true);
    PauseButton.SetActive(false);
    
}

public void Resume(){

    Time.timeScale=1;
    PauseMenu.SetActive(false);
    PauseButton.SetActive(true);
    
}

public void LoadMenu(string nameScene)
{
    UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
}

public void QuitGame()
{
    Application.Quit();
    Debug.Log("You quit the game");
}

}
