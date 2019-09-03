using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public int id;
    //idle
    public bool idle;
    public float idleTime;
    private Vector3 idleDirection;
    public float idleCooldown;
    public float idleSpeed;

    private bool changeOwnerNextUpdate;
    private SpriteRenderer spriteRenderer;

    //physics
    private Rigidbody2D rb;
    public float speed;
    private Vector3 mousePosition;
    private Vector2 direction;
    private bool followFinger;
    private Vector2 colObjectSpeed;

    private void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        idle = true;
        rb = GetComponent<Rigidbody2D>();
        followFinger = false;
    }

    public void SetId(int id)
    {
        this.id = id;
    }

    public int GetId()
    {
        return id;
    }

    void Update()
    {
        if (followFinger)
        {
            MoveWithMouse();
        }
    }
    private void OnMouseOver()
    {
        if (Input.GetMouseButton(0))
        {
            followFinger = true;
        }
    }
    void MoveWithMouse()
    {
        if (Input.GetMouseButton(0))
        {
            mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            direction = (mousePosition - transform.position).normalized;
            rb.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
        else
        {
            followFinger = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        int collisionId = 0;
        if(collision.gameObject.tag == "Wall")
        {
            collisionId = collision.gameObject.GetComponent<Wall>().GetId();

            if (id != collisionId)
                changeOwnerNextUpdate = true;
            else
            {

            }
        }
        else if(collision.gameObject.tag == "Puck")
        {
            collisionId = collision.gameObject.GetComponent<Puck>().GetId();
            Vector2 thisVelocity = rb.velocity;
            colObjectSpeed = collision.gameObject.GetComponent<Rigidbody2D>().velocity;
            //PHYSICS

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
            rb.velocity = colObjectSpeed;
            colObjectSpeed = Vector2.zero;
            changeOwnerNextUpdate = false;
        }
        if (idle)
        {
            idleTime += Time.deltaTime;
            //rb.AddForce(idleDirection * Time.deltaTime * idleSpeed);
            if (idleTime >= idleCooldown)
            {
                idleDirection = RandomDirection();
                idleTime = 0;
            }
        }
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
