﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puck : MonoBehaviour
{
    public int id;
    private int value = 1;
    public bool specialPuck;
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
    //animation
    public Animator animator;
    //trail
    public TrailRenderer trail;

    private void Awake()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        trail = GetComponent<TrailRenderer>();
    }

    private void Start()
    {
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
            collisionId = collision.gameObject.GetComponent<Wall>().GetId();
            SoundManager.instance.PlayBounceSFX();

            if (id != collisionId)
                changeOwnerNextUpdate = true;
            else
            {

            }
        }
        else if (collision.gameObject.tag == "Grey Wall")
        {
            SoundManager.instance.PlayBounceSFX();
        }
        else if(collision.gameObject.tag == "Puck")
        {
            if (!idle)
            {
                SoundManager.instance.PlayPengouinBounceSFX();
            }
            Puck collidedpuck = collision.gameObject.GetComponent<Puck>();
            collisionId = collidedpuck.GetId();
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
        if(rb.velocity.magnitude > 0.5f)
        {
            Vector2 v = rb.velocity;
            float angle = Mathf.Atan2(v.y, v.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle + 90f, Vector3.forward);
        }
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
            trail.enabled = true;
            animator.SetBool("Idle", false);
            //animator idle false
        }
        else if(collidedWithIdle)
        {
            StartIdle();
        }
    }

    private void StartIdle()
    {

        if (!this.idle)
        {
            idle = true;
            animator.SetBool("Idle", true);
            trail.enabled = false;
            //animator idle true
        }
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
            //animator.runtimeAnimatorController = GameManager.Instance.bluePuckController
            if (specialPuck)
                animator.runtimeAnimatorController = GameManager.Instance.blueMaskedPuck;
            //spriteRenderer.color = Color.HSVToRGB(0.69f, 0.67f, 0.22f);
            else
                animator.runtimeAnimatorController = GameManager.Instance.bluePuck;
                //spriteRenderer.color = Color.blue;
        }
        else
        {
            //red
            this.id = 2;
            if(specialPuck)
                animator.runtimeAnimatorController = GameManager.Instance.RedMaskedPuck;
            //spriteRenderer.color = Color.HSVToRGB(0f, 0.67f, 0.22f);
            else
                animator.runtimeAnimatorController = GameManager.Instance.RedPuck;
            //spriteRenderer.color = Color.red;
        }
    }

    public void SetSpecialPuck()
    {
        value = 3;
        specialPuck = true;
        if(id == 1)
            animator.runtimeAnimatorController = GameManager.Instance.blueMaskedPuck;
        else
            animator.runtimeAnimatorController = GameManager.Instance.RedMaskedPuck;

    }

    public int GetValue()
    {
        return value;
    }
}
