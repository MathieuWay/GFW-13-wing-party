using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public int id;
    private int value = 1;
    private bool specialPuck;
    public bool followFinger;
    //idle
    public bool idle;
    public float idleTime;
    private Vector3 idleDirection;
    public float idleCooldown;
    public float idleSpeed;
    public float startIdleBelowSpeed;
    private Vector2 colObjectSpeed;

    private bool changeOwnerNextUpdate;
    private SpriteRenderer spriteRenderer;

    //physics
    private Rigidbody2D rb;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        StartIdle();
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
        int collisionId = 0;
        if(collision.gameObject.tag == "Wall")
        {
            //collisionId = collision.gameObject.GetComponent<Wall>().GetId();
            SoundManager.instance.PlayBounceSFX();

            /*if (id != collisionId)
                changeOwnerNextUpdate = true;
            else
            {

            }*/
        }
        else if(collision.gameObject.tag == "Puck")
        {
            Puck collidedpuck = collision.gameObject.GetComponent<Puck>();
            collisionId = collidedpuck.GetId();
            Vector2 thisVelocity = rb.velocity;
            //PHYSICS
            collidedpuck.PuckCollision(idle);
            //

            if (id != collisionId)
                changeOwnerNextUpdate = true;
            else
            {

            }

        }
        else
        {
            return;
        }
    }

    private void LateUpdate()
    {
        if (changeOwnerNextUpdate)
        {
            int newId = 0;
            if (id == 1)
                newId = 2;
            else
                newId = 1;
            SwitchOwner(newId);
            changeOwnerNextUpdate = false;
        }
        if (idle)
        {
            idleTime += Time.deltaTime;
            rb.velocity = idleDirection * Time.deltaTime * idleSpeed;
            if (idleTime >= idleCooldown)
            {
                StartIdle();
            }
        }
        else
        {
            if (rb.velocity.magnitude <= startIdleBelowSpeed && !followFinger)
                StartIdle();
        }
        /*
        if(colObjectSpeed != Vector2.zero)
        {
            rb.velocity = colObjectSpeed;
            colObjectSpeed = Vector2.zero;
        }
        */
    }

    private void PuckCollision(bool collidedWithIdle)
    {
        if (this.idle)
        {
            idle = false;
        }
        else if(collidedWithIdle)
        {
            idle = true;
        }
    }

    private void StartIdle()
    {
        if (!this.idle)
            idle = true;
        if (transform.position.x < 0f)
        {
            SwitchOwner(1);
        }
        else
        {
            SwitchOwner(2);
        }
        idleDirection = RandomDirection();
        idleTime = 0;
    }

    private Vector3 RandomDirection()
    {
        return new Vector3(Random.Range(-1f, 1f), Random.Range(-1f, 1f), 0);
    }


    public void SwitchOwner(int newOwner)
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        if (newOwner == 1)
        {
            //blue
            this.id = 1;
            if (specialPuck)
                spriteRenderer.color = Color.HSVToRGB(0.69f, 0.67f, 0.22f);
            else
                spriteRenderer.color = Color.blue;
        }
        else
        {
            //red
            this.id = 2;
            if(specialPuck)
                spriteRenderer.color = Color.HSVToRGB(0f, 0.67f, 0.22f);
            else
                spriteRenderer.color = Color.red;
        }
    }

    public void SetSpecialPuck()
    {
        value = 3;
        specialPuck = true;
        if(id == 1)
            spriteRenderer.color = Color.HSVToRGB(0.69f, 0.67f, 0.22f);
        else
            spriteRenderer.color = Color.HSVToRGB(0f, 0.67f, 0.22f);

    }

    public int GetValue()
    {
        return value;
    }
}
