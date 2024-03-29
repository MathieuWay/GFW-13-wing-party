﻿using System.Collections;
using System.Collections.Generic;

public class Player
{
    private static readonly int winScoreCondition = 10;
    private readonly int id;
    private int score;
    private bool blockActivated;
    private float blockCooldown;
    private float blockCooldownDelay;
    private float blockDuration;

    public Player(int id)
    {
        this.id = id;
        this.score = 0;
        this.blockCooldownDelay = 0;
    }

    public void AddScore(int amount)
    {
        this.score += amount;
    }

    public int GetScore()
    {
        return this.score;
    }

    public int GetId()
    {
        return this.id;
    }

    public bool GetBlockActivated()
    {
        return this.blockActivated;
    }

    public void SetBlockActivated(bool state)
    {
        blockActivated = state;
    }

    public float GetBlockDuration()
    {
        return this.blockDuration;
    }

    public void SetBlockDuration(float time)
    {
        blockDuration = time;
    }

    public float GetDowntime()
    {
        return this.blockCooldown;
    }

    public void SetDowntime(float time)
    {
        blockCooldown = time;
    }

    public float GetDowntimeBonus()
    {
        return this.blockCooldownDelay;
    }

    public void SetDowntimeBonus(float time)
    {
        blockCooldownDelay = time;
    }
}
