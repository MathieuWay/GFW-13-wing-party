using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TriggerGoal : MonoBehaviour
{
    public int id;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Puck")
        {
            int puckId = collision.gameObject.GetComponent<Puck>().GetId();
            //TODO If puck is different color from triggerOwner
            if (id != puckId)
            {
                SoundManager.instance.PlayGoalSFX();
                GameManager.Instance.AddScore(puckId, 1);
            }
            GameObject.Destroy(collision.gameObject);
            GameManager.Instance.SpawnPuck(puckId);
        }
    }
}
