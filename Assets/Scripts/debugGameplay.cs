using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class debugGameplay : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
            GameManager.Instance.AddScore(1, 1);
        if (Input.GetKeyDown(KeyCode.Alpha2))
            GameManager.Instance.AddScore(2, 1);
    }
}
