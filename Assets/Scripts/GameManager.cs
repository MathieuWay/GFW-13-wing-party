using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool onPause;
    private Player playerOne;
    private Player playerTwo;

    public GameObject puckPrefabs;
    public int spawnAreaWidth;
    public int spawnAreaHeight;
    public int deadZone;

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

    // Start is called before the first frame update
    void Start()
    {
        playerOne = new Player(1);
        playerTwo = new Player(2);
        if (!debug)
        {
            for (int i = 0; i < 4; i++)
            {
                SpawnPuck(1);
                SpawnPuck(2);
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        
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
        GameObject newPuck = Instantiate(puckPrefabs, pos, Quaternion.identity);
        newPuck.GetComponent<Puck>().SwitchOwner(owner);
    }
}
