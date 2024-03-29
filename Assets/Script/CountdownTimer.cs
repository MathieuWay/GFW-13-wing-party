﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class CountdownTimer : MonoBehaviour
{
    public static float currentTime=0;
    float startingTime=90f;
    public GameObject Endcard,HUD;


    [SerializeField] Text countdownText;
    [SerializeField] Text countdownText1;

    bool isSoundPlayed = false;

    // Start is called before the first frame update
    void Start()
    {
     
        currentTime=startingTime;
        isSoundPlayed = false;

    }

    // Update is called once per frame
    void Update()
    {

        
        currentTime -=1 * Time.deltaTime;
        
        countdownText.text = currentTime.ToString("0");
        countdownText1.text = currentTime.ToString("0");


        if(currentTime<=0)
        {
            //Debug.Log("Le timer est passé dans le négatif"); 
            Endcard.SetActive(true);
            if (!isSoundPlayed)
            {
                SoundManager.instance.PlayRoundSFX();
                isSoundPlayed = true;
            }
            HUD.SetActive(false);

        }


        if(currentTime<=-3 || Input.GetKeyDown("a"))
        {
            
            Application.LoadLevel(Application.loadedLevel);

        }
    }
}

