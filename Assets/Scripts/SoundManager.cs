using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource goalSFX;
    public AudioSource BounceSFX;
    public AudioSource pengouinBounceSFX;
    public AudioSource victorySFX;

    public AudioClip[] bounceArray;

    public AudioClip[] wallBounceArray;

    public AudioClip[] goalArray;

    public AudioClip[] victoryArray;

    public static SoundManager instance;


    private void Awake()
    {
        instance = this;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayGoalSFX()
    {
        goalSFX.clip = goalArray[0];
        goalSFX.Play();
    }

    public void PlayMaskedGoalSFX()
    {
        goalSFX.clip = goalArray[1];
        goalSFX.Play();
    }

    public void PlayBounceSFX()
    {
        BounceSFX.clip = wallBounceArray[Random.Range(0, wallBounceArray.Length)];
        BounceSFX.Play();
    }

    public void PlayPengouinBounceSFX()
    {
        pengouinBounceSFX.clip = bounceArray[Random.Range(0, bounceArray.Length)];
        pengouinBounceSFX.Play();
    }

    public void PlayRoundSFX()
    {
        victorySFX.clip = victoryArray[0];
        victorySFX.Play();
    }

    public void PlayVictorySFX()
    {
        victorySFX.clip = victoryArray[1];
        victorySFX.Play();
    }

}
