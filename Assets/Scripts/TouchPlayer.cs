using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayer : MonoBehaviour
{
    private GameObject puckTarget;
    private Rigidbody2D puckTargetRigidBody;
    private Puck TargetPuck;
    public float speed;
    private Vector3 mousePosition;
    private Vector2 direction;
    private bool followFinger;
    // Start is called before the first frame update
    void Start()
    {
        followFinger = false;

    }

    // Update is called once per frame
    void Update()
    {
        /*
        if (Input.GetMouseButton(0))
        {

        }
        else
        {
            followFinger = false;
        }*/
        if (Input.GetMouseButtonDown(0))
        {
            int id = 0;
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (mousePosition.x < 0)
                id = 1;
            else
                id = 2;
            RaycastHit2D hit = Physics2D.Raycast(mousePosition, mousePosition);
            if (hit.collider && hit.collider.tag == "Puck")
            {
                int idPuck = hit.collider.GetComponent<Puck>().GetId();
                if(id == idPuck)
                {
                    Debug.Log("target found");
                    puckTarget = hit.collider.gameObject;
                    puckTargetRigidBody = puckTarget.GetComponent<Rigidbody2D>();
                    TargetPuck = puckTarget.GetComponent<Puck>();
                    TargetPuck.idle = false;
                    TargetPuck.followFinger = true;
                }
                //do stuff
            }

        }

        if (Input.GetMouseButtonUp(0) && puckTarget != null)
        {
            TargetPuck.followFinger = false;
            puckTargetRigidBody = null;
            puckTarget = null;
        }

        if(puckTarget != null)
            PuckFollow();
        /**/
    }

    private void PuckFollow()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        direction = (mousePosition - puckTarget.transform.position).normalized;
        puckTargetRigidBody.velocity = new Vector2(direction.x * speed, direction.y * speed);
    }
}
