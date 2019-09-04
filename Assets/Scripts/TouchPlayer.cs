using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayer : MonoBehaviour
{
    private GameObject puckTarget;
    private Rigidbody2D puckTargetRigidBody;
    private Puck TargetPuck;
    int id = 0;
    public float speed;
    private Vector3 mousePosition;
    private Vector2 direction;
    // Start is called before the first frame update
    void Start()
    {

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
            unlinkPuck();
        }

        if(puckTarget != null)
            PuckFollow();
        /**/
    }

    private void PuckFollow()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if((mousePosition.x < 0 && id == 1) || (mousePosition.x > 0 && id == 2))
        {
            direction = (mousePosition - puckTarget.transform.position).normalized;
            puckTargetRigidBody.velocity = new Vector2(direction.x * speed, direction.y * speed);
        }
        else
        {
            unlinkPuck();
        }
    }

    private void unlinkPuck()
    {
        TargetPuck.followFinger = false;
        puckTargetRigidBody = null;
        puckTarget = null;
    }
}
