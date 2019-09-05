using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadLevel : MonoBehaviour{


public void LoadLvl(string nameScene)
{
    GetComponent<AudioSource>().Play();
    UnityEngine.SceneManagement.SceneManager.LoadScene(nameScene);
}

public void QuitGame()
{
    Application.Quit();
    Debug.Log("You quit the game");
}

}

