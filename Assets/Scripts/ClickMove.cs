using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickMove : MonoBehaviour
{
    private Rigidbody2D rb;
    public float speed;
    private Vector3 mousePosition;
    private Vector2 direction;
    private bool followFinger;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        followFinger = false;
    }

    private void FixedUpdate()
    {
        
    }

    // Update is called once per frame
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
}
