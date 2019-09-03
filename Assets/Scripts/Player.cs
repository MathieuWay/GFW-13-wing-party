using System.Collections;
using System.Collections.Generic;

public class Player
{
    private static readonly int winScoreCondition = 10;
    private readonly int id;
    private int score;

    public Player(int id)
    {
        this.id = id;
        this.score = 0;
    }

    public void AddScore(int amount)
    {
        this.score += amount;
        if (this.score >= winScoreCondition)
            GameManager.Instance.TriggerWin(this.id);
    }

    public int GetScore()
    {
        return this.score;
    }
}
