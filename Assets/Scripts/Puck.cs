using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public int id;
    private SpriteRenderer spriteRenderer;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public int GetId()
    {
        return id;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //Debug.Log("collision my id:"+this.id+ "colliding with id:"+ collision.gameObject.GetComponent<Puck>().GetId());
        int collisionId = 0;
        if(collision.gameObject.tag == "Wall")
        {
            collisionId = collision.gameObject.GetComponent<Wall>().GetId();

            if (id != collisionId)
                SwitchOwner(collisionId);
            else
            {

            }
        }
        else if(collision.gameObject.tag == "Puck")
        {
            collisionId = collision.gameObject.GetComponent<Puck>().GetId();
            Debug.Log(collisionId);

            if (id != collisionId)
                SwitchOwner(collisionId);
            else
            {

            }

        }
        else
        {
            return;
        }
    }
    

    public void SwitchOwner(int newOwner)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (newOwner == 1)
        {
            //blue
            this.id = 1;
            spriteRenderer.color = Color.blue;
        }
        else
        {
            //red
            this.id = 2;
            spriteRenderer.color = Color.red;
        }
    }
}
