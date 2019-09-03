using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue_p1=0;
    public static int scoreValue_p2=0;
    private static float timer;
    private int wins_p1=0;
    private int wins_p2=0;
    Text score;
    [SerializeField] Text winnerName;
    
    

    // Start is called before the first frame update
    void Start()
    {
        scoreValue_p1=0;
        scoreValue_p2=0;
        score = GetComponent<Text>();

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
            
        }

        if (scoreValue_p1<scoreValue_p2)
        {
            winnerName.text = "Le joueur 2 remporte cette manche";

        }

        if (scoreValue_p1==scoreValue_p2)
        {
            winnerName.text = "Egalité ! Chaque joueur remporte un point";

        }
        timer=CountdownTimer.currentTime;

        if(timer<=0){
        Debug.Log("Le timer est passé dans le négatif");
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
