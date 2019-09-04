using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue_p1=0;
    public static int scoreValue_p2=0;
    public static float timer;
    public static int wins_p1=0;
    public static int wins_p2=0;
    public static bool p1wonfirstset=false;
    public static bool p2wonfirstset=false;
    public static bool p1wonsecondset=false;
    public static bool p2wonsecondset=false;
    public static bool p1wonthirdset=false;
    public static bool p2wonthirdset=false;
    public static bool equality=false;
    public static int numberofrounds=0;
    public GameObject gameEnded,endcard,HUD,p1wonset1,p1wonset2,p1wonset3,p2wonset1,p2wonset2,p2wonset3;
    Text score;
    [SerializeField] Text winnerName;
    [SerializeField] Text winnerName2;
    [SerializeField] Text finalWinner;
    [SerializeField] Text finalWinner2;
    
    

    // Start is called before the first frame update
    void Start()
    {
        scoreValue_p1=0;
        scoreValue_p2=0;
        score = GetComponent<Text>();
        if (score.tag == "Player1")if(equality==false){
        {
            numberofrounds=numberofrounds+1;
        }
        }
        Debug.Log("This is round number " + numberofrounds);
        if(equality==true){
            equality=false;
            Debug.Log("There was a tie in the previous round");
        }

    }

    // Update is called once per frame
    void Update()
    {

        if (score.tag == "Player1" )
        {
            score.text = "Score : "+scoreValue_p1;
        }

        if (score.tag == "Player2" )
        {
            score.text = "Score : "+scoreValue_p2;
        }

        if (scoreValue_p1>scoreValue_p2)
        {
            winnerName.text = "Le joueur 1 remporte cette manche";
            winnerName2.text = "Le joueur 1 remporte cette manche";
            
        }

        if (scoreValue_p1<scoreValue_p2)
        {
            winnerName.text = "Le joueur 2 remporte cette manche";
            winnerName2.text = "Le joueur 1 remporte cette manche";

        }

        if (scoreValue_p1==scoreValue_p2)
        {
            winnerName.text = "Egalité ! Chaque joueur remporte un point";
            winnerName2.text = "Le joueur 1 remporte cette manche";

        }


        if(CountdownTimer.currentTime<1f){
        
            if (scoreValue_p1>scoreValue_p2){

             if(p1wonfirstset==false && p2wonfirstset==false){

                p1wonfirstset=true;
            }

            if(p1wonfirstset==true || p2wonfirstset==true){
                if(numberofrounds==2){
                    
                p1wonsecondset=true;
                }
            }

            if(p1wonsecondset==true && p2wonfirstset==true){
                if(numberofrounds==3){

                 p1wonthirdset=true;
                 }

             }

             if(p1wonfirstset==false && p2wonsecondset==true){
                 if(numberofrounds==3){

                 p1wonthirdset=true;
                }
             }

            }
        

            if (scoreValue_p1<scoreValue_p2){

                if(p1wonfirstset==false && p2wonfirstset==false){

                    p2wonfirstset=true;

                }

            if(p1wonfirstset==true || p2wonfirstset==true){
                if(numberofrounds==2){

                p2wonsecondset=true;

                }
            }

             if(p1wonsecondset==true && p2wonfirstset==true){
                 if(numberofrounds==3){

                 p2wonthirdset=true;

             }
             }

             if(p1wonfirstset==true && p2wonsecondset==true){
                 if(numberofrounds==3){

                 p2wonthirdset=true;

             }
             }
             

            }
            if(scoreValue_p1==scoreValue_p2){
                equality=true;
                Debug.Log("This is a tie");
            }
        }
        
        if(p1wonfirstset && p1wonsecondset){
            gameEnded.SetActive(true);
            Time.timeScale=0;
            finalWinner.text = "Le joueur 1 remporte la partie";
            finalWinner2.text = "Le joueur 1 remporte la partie";
            p1wonset1.SetActive(true);
            p1wonset2.SetActive(true);
        }

        if(p1wonfirstset && p1wonthirdset){
            gameEnded.SetActive(true);
            Time.timeScale=0;
            finalWinner.text = "Le joueur 1 remporte la partie";
            p1wonset1.SetActive(true);
            p2wonset2.SetActive(true);
            p1wonset3.SetActive(true);
        }

        if(p1wonsecondset && p1wonthirdset){
            gameEnded.SetActive(true);
            Time.timeScale=0;
            finalWinner.text = "Le joueur 1 remporte la partie";
            finalWinner2.text = "Le joueur 1 remporte la partie";
            p2wonset1.SetActive(true);
            p1wonset2.SetActive(true);
            p1wonset3.SetActive(true);
        }
        
        if(p2wonfirstset && p2wonsecondset){
            gameEnded.SetActive(true);
            Time.timeScale=0;
            finalWinner.text = "Le joueur 2 remporte la partie";
            finalWinner2.text = "Le joueur 2 remporte la partie";
            p2wonset1.SetActive(true);
            p2wonset2.SetActive(true);
        }

        if(p2wonfirstset && p2wonthirdset){
            gameEnded.SetActive(true);
            Time.timeScale=0;
            finalWinner.text = "Le joueur 2 remporte la partie";
            finalWinner2.text = "Le joueur 2 remporte la partie";
            p2wonset1.SetActive(true);
            p1wonset2.SetActive(true);
            p2wonset3.SetActive(true);
        }

        if(p2wonsecondset && p2wonthirdset){
            gameEnded.SetActive(true);
            Time.timeScale=0;
            finalWinner.text = "Le joueur 2 remporte la partie";
            finalWinner2.text = "Le joueur 2 remporte la partie";
            p1wonset1.SetActive(true);
            p2wonset2.SetActive(true);
            p2wonset3.SetActive(true);
        }
    }
        
        
    

    
    public void Scoretest_p1()
    {

        scoreValue_p1 +=1;

    }


    public void Scoretest_p2()
    {

        scoreValue_p2 +=1;

    }


}
