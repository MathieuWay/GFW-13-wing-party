using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TutorialSystem : MonoBehaviour
{
    private int countdown=0;
    private int skipcount_p1=0;
    private int skipcount_p2=0;
    public static bool tutorialskipped=false;
    public GameObject text1, text2, text3, text4, tutorialPopUp, HUD, timer;

    // Start is called before the first frame update
    void Start()
    {
        if(tutorialskipped==true){
            tutorialPopUp.SetActive(false);
            HUD.SetActive(true);
            timer.SetActive(true);
            
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(skipcount_p1==skipcount_p2){

            countdown=skipcount_p1;

        }
        
        if(countdown==1){
            text1.SetActive(false);
            text2.SetActive(true);
        }
        if(countdown==2){
            text2.SetActive(false);
            text3.SetActive(true);
        }
        if(countdown==3){
            text3.SetActive(false);
            text4.SetActive(true);
        }
        if(countdown==4){
            tutorialPopUp.SetActive(false);
            HUD.SetActive(true);
            timer.SetActive(true);
            tutorialskipped=true;
        }
    }

    public void Skip_p1(){
        
        if(countdown==0){
            skipcount_p1=1;
        }
        if(countdown==1){
            skipcount_p1=2;
        }
        if(countdown==2){
            skipcount_p1=3;
        }
        if(countdown==3){
            skipcount_p1=4;
        }

    }

    public void Skip_p2(){
        
        if(countdown==0){
            skipcount_p2=1;
        }
        if(countdown==1){
            skipcount_p2=2;
        }
        if(countdown==2){
            skipcount_p2=3;
        }
        if(countdown==3){
            skipcount_p2=4;
        }
}

}