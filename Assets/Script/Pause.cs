using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Pause : MonoBehaviour{

public GameObject PauseMenu;

public void Paused(){

    Time.timeScale=0;
    PauseMenu.SetActive(true);
    
}

public void Resume(){

    Time.timeScale=1;
    PauseMenu.SetActive(false);
    
}


}
