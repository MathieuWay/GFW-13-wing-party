using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchPlayer : MonoBehaviour
{
    //private GameObject puckTarget;
    int id = 0;
    public float speed;
    private Vector3 mousePosition;
    private Vector2 direction;

    private TouchLink[] touches;
    //PLAYER ONE TARGET
    //PLAYER two TARGET
    public Touch playerTwoTouch;
    public GameObject playerTwoTarget;
    private Rigidbody2D playerTwoRigidBody;
    private Puck playerTwoPuck;
    // Start is called before the first frame update
    void Start()
    {
        touches = new TouchLink[10];
    }

    // Update is called once per frame
    void Update()
    {
#if UNITY_EDITOR
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            if (pos.x < 0)
            {
                id = 1;
            }
            else
            {
                id = 2;
            }
            RaycastHit2D hit = Physics2D.Raycast(pos, pos);
            if (hit.collider && hit.collider.tag == "Puck")
            {
                int idPuck = hit.collider.GetComponent<Puck>().GetId();
                if (id == idPuck)
                {
                    touches[0] = new TouchLink(id, Input.mousePosition, hit.collider.gameObject, hit.collider.gameObject.GetComponent<Rigidbody2D>(), hit.collider.gameObject.GetComponent<Puck>());
                }
            }
        }
        else if (Input.GetMouseButton(0) && touches[0] != null)
        {
            touches[0].pos = Input.mousePosition;
        }
        else if(Input.GetMouseButtonUp(0) && touches[0] != null)
        {
            touches[0].Unlink();
            touches[0] = null;
        }
#endif
#if UNITY_ANDROID
        for (int i = 0; i < Input.touches.Length; i++)
        {
            Touch touch = Input.touches[i];
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    Vector3 pos = Camera.main.ScreenToWorldPoint(touch.position);
                    if (pos.x < 0)
                    {
                        id = 1;
                    }
                    else
                    {
                        id = 2;
                    }
                    RaycastHit2D hit = Physics2D.Raycast(pos, pos);
                    if (hit.collider && hit.collider.tag == "Puck")
                    {
                        int idPuck = hit.collider.GetComponent<Puck>().GetId();
                        if (id == idPuck)
                        {
                            touches[i] = new TouchLink(id, touch.position, hit.collider.gameObject, hit.collider.gameObject.GetComponent<Rigidbody2D>(), hit.collider.gameObject.GetComponent<Puck>());
                        }
                    }
                    break;
                case TouchPhase.Ended:
                    if (touches[i] != null)
                    {
                        touches[i].Unlink();
                        touches[i] = null;
                    }
                    break;
                case TouchPhase.Moved:
                    if(touches[i] != null)
                        touches[i].pos = touch.position;
                    break;

            }
            /*foreach (Touch touch in Input.touches)
            {
                if (touch.phase != TouchPhase.Ended && touch.phase != TouchPhase.Canceled)
                {
                    if ((id == 1 && playerOneTarget == null) || (id == 2 && playerTwoTarget == null))
                    {
                        PuckTargeting(touch, pos, id);
                    }
                }
                else{
                    if(id == 1)
                    {
                        if (playerOneTarget != null)
                        {
                            unlinkPuck(id);
                        }
                    }
                    else
                    {
                        if (playerTwoTarget != null)
                        {
                            unlinkPuck(id);
                        }
                    }

                }
            }*/
#endif

            /*
            if (playerOneTarget != null)
                PuckFollow(1, playerOneTarget, playerOneRigidBody, playerOneTouch.position);

            if (playerTwoTarget != null)
                PuckFollow(2, playerTwoTarget, playerTwoRigidBody, playerTwoTouch.position);
            */
            /**/
        }

        for (int j = 0; j < touches.Length; j++)
        {
            if (touches[j] != null)
            {

                PuckFollow(j, touches[j].playerId, touches[j].Target, touches[j].RigidBody, touches[j].pos);
            }
        }
    }

        /*private void PuckTargeting(Touch touch, Vector2 pos, int id)
        {
            RaycastHit2D hit = Physics2D.Raycast(pos, pos);
            if (hit.collider && hit.collider.tag == "Puck")
            {
                int idPuck = hit.collider.GetComponent<Puck>().GetId();
                if (id == idPuck)
                {
                    if (id == 1)
                    {
                        playerOneTouch = touch;
                        playerOneTarget = hit.collider.gameObject;
                        playerOneRigidBody = playerOneTarget.GetComponent<Rigidbody2D>();
                        playerOnePuck = playerOneTarget.GetComponent<Puck>();
                        playerOnePuck.idle = false;
                        playerOnePuck.followFinger = true;
                    }
                    else
                    {
                        playerTwoTouch = touch;
                        playerTwoTarget = hit.collider.gameObject;
                        playerTwoRigidBody = playerTwoTarget.GetComponent<Rigidbody2D>();
                        playerTwoPuck = playerTwoTarget.GetComponent<Puck>();
                        playerTwoPuck.idle = false;
                        playerTwoPuck.followFinger = true;
                    }
                }
            }
        }*/

        private void PuckFollow(int linkIndex, int id, GameObject puckTarget, Rigidbody2D puckTargetRigidBody, Vector3 posScreen)
        {
            Vector3 pos = Camera.main.ScreenToWorldPoint(posScreen);
            if ((pos.x < 0 && id == 1) || (pos.x > 0 && id == 2))
            {
                direction = (pos - puckTarget.transform.position).normalized;
                puckTargetRigidBody.velocity = new Vector2(direction.x * speed, direction.y * speed);
            }
            else
            {
                touches[linkIndex].Unlink();
                touches[linkIndex] = null;
            }
        }

        /*private void unlinkPuck(int id)
        {
            Debug.Log("unlink Puck !!");
            if (id == 1)
            {
                playerOnePuck.followFinger = false;
                playerOneRigidBody = null;
                playerOneTarget = null;
            }
            else
            {
                playerTwoPuck.followFinger = false;
                playerTwoRigidBody = null;
                playerTwoTarget = null;
            }
        }*/
    }

public class TouchLink
{
    public int playerId;
    public Vector2 pos;
    public GameObject Target;
    public Rigidbody2D RigidBody;
    public Puck Puck;

    public TouchLink()
    {
        this.playerId = 0;
        this.pos = Vector2.zero;
        this.Target = null;
        this.RigidBody = null;
        this.Puck = null;
    }
    public TouchLink(int playerId, Vector2 pos, GameObject Target, Rigidbody2D RigidBody, Puck Puck)
    {
        this.playerId = playerId;
        this.pos = pos;
        this.Target = Target;
        this.RigidBody = RigidBody;
        this.Puck = Puck;

        this.Puck.idle = false;
        this.Puck.followFinger = true;
    }

    public void Unlink()
    {
        this.Puck.followFinger = false;
    }
}
