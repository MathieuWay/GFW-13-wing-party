using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    public AudioSource goalSFX;
    public AudioSource BounceSFX;
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
        goalSFX.Play();
    }

    public void PlayBounceSFX()
    {
        BounceSFX.Play();
    }


}
