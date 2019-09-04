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
            Puck puck = collision.gameObject.GetComponent<Puck>();
            int puckId = puck.GetId();
            //TODO If puck is different color from triggerOwner
            if (id != puckId)
            {
                GameManager.Instance.AddScore(puckId, puck.GetValue());
                SoundManager.instance.PlayGoalSFX();
            }
            GameObject.Destroy(collision.gameObject);
            GameManager.Instance.SpawnPuck(puckId);
        }
    }
}
