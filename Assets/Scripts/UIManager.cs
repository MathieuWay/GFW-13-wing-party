﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIManager : MonoBehaviour
{
    public TextMeshProUGUI scorePlayerOne;
    public TextMeshProUGUI scorePlayerTwo;

    public Button BlockButtonPlayerOne;
    public Button BlockButtonPlayerTwo;

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

    public void SetBlockButtonState(int id, bool state)
    {
        if (id == 1)
        {
            BlockButtonPlayerOne.enabled = state;
            if (state)
                BlockButtonPlayerOne.GetComponentInChildren<TextMeshProUGUI>().text = "Ready";
        }
        else
        {
            BlockButtonPlayerTwo.enabled = state;
            if (state)
                BlockButtonPlayerTwo.GetComponentInChildren<TextMeshProUGUI>().text = "Ready";
        }
    }

    public void UpdateBlockCooldown(int id, float time)
    {
        float cooldownMax = GameManager.Instance.BlockCoolDown + GameManager.Instance.GetPlayer(id).GetDowntimeBonus();
        if (id == 1)
            BlockButtonPlayerOne.GetComponentInChildren<TextMeshProUGUI>().text = (cooldownMax - time).ToString("0");
        else
            BlockButtonPlayerTwo.GetComponentInChildren<TextMeshProUGUI>().text = (cooldownMax - time).ToString("0");
    }

    public void StartBlock(int id)
    {
        if(id == 1)
        {
            SetBlockButtonState(id, false);
            BlockButtonPlayerOne.GetComponentInChildren<TextMeshProUGUI>().text = "ACTIVATED";
        }
        else
        {
            SetBlockButtonState(id, false);
            BlockButtonPlayerTwo.GetComponentInChildren<TextMeshProUGUI>().text = "ACTIVATED";
        }

    }
}
