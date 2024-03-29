﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool onPause;
    private Player playerOne;

    private Player playerTwo;
    public int minPuckPerSide;
    public int maxPuckPerSide;
    public int specialPuckSpawnChance;
    public GameObject puckPrefabs;
    public int spawnAreaWidth;
    public int spawnAreaHeight;
    public int deadZone;

    //Special
    public float BlockMaxDuration;
    public float BlockCoolDown;
    public float incrementCooldown;
    public GameObject blockPlayer1;
    public GameObject blockPlayer2;

    //Anim Controller
    public RuntimeAnimatorController bluePuck;
    public RuntimeAnimatorController RedPuck;
    public RuntimeAnimatorController blueMaskedPuck;
    public RuntimeAnimatorController RedMaskedPuck;

    public bool debug;

    private static GameManager instance;
    public static GameManager Instance
    {
        get
        {
            if (instance == null)
                instance = GameObject.FindObjectOfType<GameManager>();
            if (instance == null)
                Debug.Log("No GameManager found");
            return instance;
        }
    }

    private void Awake()
    {
        playerOne = new Player(1);
        playerTwo = new Player(2);
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!debug)
        {
            for (int i = 0; i < minPuckPerSide; i++)
            {
                SpawnPuck(1);
                SpawnPuck(2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        BlockTiming(playerOne, blockPlayer1);
        BlockTiming(playerTwo, blockPlayer2);
        int PuckSide = 0;
        PuckSide = countPuckOnSide(1);
        if (PuckSide < minPuckPerSide)
            SpawnPuck(1);
        else if (PuckSide > maxPuckPerSide)
            DespawnPuck(1);

        PuckSide = countPuckOnSide(2);
        if (countPuckOnSide(2) < minPuckPerSide)
            SpawnPuck(2);
        else if (PuckSide > maxPuckPerSide)
            DespawnPuck(2);

    }

    public void BlockTiming(Player player, GameObject block)
    {
        if (player.GetBlockActivated())
        {
            float duration = player.GetBlockDuration();
            if (duration < BlockMaxDuration)
                player.SetBlockDuration(duration + Time.deltaTime);
            else
            {
                player.SetBlockActivated(false);
                block.SetActive(false);
                player.SetDowntimeBonus(player.GetDowntimeBonus() + incrementCooldown);
            }
        }
        else
        {
            float downtime = player.GetDowntime();
            if (downtime < (BlockCoolDown + player.GetDowntimeBonus()))
            {
                float downTime = downtime + Time.deltaTime;
                player.SetDowntime(downTime);
                UIManager.Instance.UpdateBlockCooldown(player.GetId(), downTime);
            }
            else
            {
                UIManager.Instance.SetBlockButtonState(player.GetId(), true);
            }
        }
    }

    public void TriggerWin(int id)
    {
        PauseGame();
        Debug.Log("Joueur " + id + " win");
    }

    public void PauseGame()
    {
        if (!onPause)
        {
            Time.timeScale = 0;
        }
        else
        {
            //TODO Resume Animation
            Time.timeScale = 1;
        }
        onPause = !onPause;
    }

    public void AddScore(int id, int amount)
    {
        if (id == 1)
        {

            playerOne.AddScore(amount);
            UIManager.Instance.UpdateScore(id, playerOne.GetScore());
        }
        else
        {
            playerTwo.AddScore(amount);
            UIManager.Instance.UpdateScore(id, playerTwo.GetScore());
        }
    }

    public void SpawnPuck(int owner)
    {
        Vector3 pos = new Vector3(Random.Range(deadZone, spawnAreaWidth / 2f), Random.Range(-(spawnAreaHeight/2f), spawnAreaHeight/2f), 0);
        if (owner == 1)
            pos.x = -pos.x;
        Puck newPuck = Instantiate(puckPrefabs, pos, Quaternion.identity).GetComponent<Puck>();
        newPuck.SwitchOwner(owner);
        if (Random.Range(0f, 100f) < specialPuckSpawnChance)
        {
            newPuck.SetSpecialPuck();
        }
    }

    public void DespawnPuck(int owner)
    {
        Puck[] pucks = GameObject.FindObjectsOfType<Puck>();
        int i=0;
        while (pucks[i].GetId() != owner) i++;
        Destroy(pucks[i].gameObject);
    }

    private int countPuckOnSide(int id)
    {
        Puck[] pucks = GameObject.FindObjectsOfType<Puck>();
        int count = 0;
        foreach(Puck puck in pucks)
        {
            if (id == puck.GetId())
                count++;
        }
        return count;
    }

    public void TriggerBlock(int id)
    {
        if(id == 1)
        {
            if (playerOne.GetDowntime() >= BlockCoolDown)
                StartBlock(playerOne, blockPlayer1);
        }
        else
        {
            if (playerTwo.GetDowntime() >= BlockCoolDown)
                StartBlock(playerTwo, blockPlayer2);
        }
    }

    public void StartBlock(Player player, GameObject block)
    {
        player.SetBlockActivated(true);
        player.SetBlockDuration(0f);
        player.SetDowntime(0);
        UIManager.Instance.StartBlock(player.GetId());
        block.SetActive(true);
    }

    public Player GetPlayer(int id)
    {
        if (id == 1)
            return playerOne;
        else
            return playerTwo;
    }
}
