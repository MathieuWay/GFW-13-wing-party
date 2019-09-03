using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scorePlayerOne;
    public TextMeshProUGUI scorePlayerTwo;

    private static UIManager instance;
    public static UIManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<UIManager>();
            if (instance == null)
                Debug.Log("No UIManager found");
            return instance;
        }
    }

    public void UpdateScore(int id, int amount)
    {
        if (id == 1)
        {
            scorePlayerOne.text = amount.ToString();
        }
        else
        {
            scorePlayerTwo.text = amount.ToString();
        }
    }
}
