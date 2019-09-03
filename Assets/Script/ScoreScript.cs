using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour
{

    public static int scoreValue_p1=0;
    public static int scoreValue_p2=0;
    Text score;

    // Start is called before the first frame update
    void Start()
    {
        
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
        
    }

    public void Scoretest_p1()
    {

        scoreValue_p1 +=10;

    }

    public void Scoretest_p2()
    {

        scoreValue_p2 +=10;

    }
}
