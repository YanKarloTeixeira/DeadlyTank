/*
 ____                 _ _         _____           _    
|  _ \  ___  __ _  __| | |_   _  |_   _|_ _ _ __ | | __
| | | |/ _ \/ _` |/ _` | | | | |   | |/ _` | '_ \| |/ /
| |_| |  __/ (_| | (_| | | |_| |   | | (_| | | | |   < 
|____/ \___|\__,_|\__,_|_|\__, |   |_|\__,_|_| |_|_|\_\
                          |___/                        
                          By: Yan Karlo                
                              Shila Das                
                              Nikesh Patel             
                                                       
*/

using Assets.Scripts.Objects;
using UnityEngine;

public class Player2 : MonoBehaviour
{
    //PUBLIC VARIABLES
    public float speed = 1f;
    public float jumpForce = 500;
    public bool Moving_UP = false;
    public bool Moving_Down = false;
    public bool Moving_Left = false;
    public bool Moving_Right = false;

    //Players
    public KeyController GoTo;
    public Tank TankPlayer;

    //PRIVATE VARIABLES
    private Rigidbody2D rBody;
    public Track trackLeft;
    public Track trackRight;

    // Reserved function. Run only once when the object is /// <summary>
    // User for initialization.
    void Start()
    {
        rBody = GameObject.FindGameObjectWithTag("Player2").GetComponent<Rigidbody2D>();
        GoTo = new KeyController(2);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rBody.AddForce(new Vector2(0,jumpForce));

        }
    }

    ///<summary>
    /// This function is called every framerate frame, if the monobehaviour is private void OnFailedToConnect(NetworkConnectionError error) {
    /// Use FixedUpdate for Physics-based movement only.!--
    ///</summary>

    void FixedUpdate()
    {
        speed = 1f;
        float horiz = Input.GetAxis("Horizontal_P2");
        float vert = Input.GetAxis("Vertical_P2");

        Moving_UP = Input.GetKey(GoTo.Up);
        Moving_Down = Input.GetKey(GoTo.Down);
        Moving_Left = Input.GetKey(GoTo.Left);
        Moving_Right = Input.GetKey(GoTo.Right);


        if (Input.GetKey(GoTo.Up) && Input.GetKey(GoTo.Left))
        {
            rBody.rotation = 45;
            rBody.velocity = new Vector2(horiz - speed, vert + speed);
            trackStart();
        }
        else if (Input.GetKey(GoTo.Up) && Input.GetKey(GoTo.Right))
        {
            rBody.rotation = -45;
            rBody.velocity = new Vector2(horiz + speed, vert + speed);
            trackStart();
        }
        else if (Input.GetKey(GoTo.Down) && Input.GetKey(GoTo.Left))
        {
            rBody.rotation = 135;
            rBody.velocity = new Vector2(horiz - speed, vert - speed);
            trackStart();
        }
        else if (Input.GetKey(GoTo.Down) && Input.GetKey(GoTo.Right))
        {
            rBody.rotation = -135;
            rBody.velocity = new Vector2(horiz + speed, vert - speed);
            trackStart();
        }
        else if (Input.GetKey(GoTo.Up))
        {
            rBody.rotation = 0;
            rBody.velocity = new Vector2(horiz, vert + speed);
            trackStart();
        }
        else if (Input.GetKey(GoTo.Down))
        {
            rBody.rotation = 180;
            rBody.velocity = new Vector2(horiz, vert - speed);
            trackStart();
        }
        else if (Input.GetKey(GoTo.Left) && !(Input.GetKey(GoTo.Up) || Input.GetKey(GoTo.Down)))
        {
            rBody.rotation = 90;
            rBody.velocity = new Vector2(horiz - speed, vert);
            trackStart();
        }
        else if (Input.GetKey(GoTo.Right) && !(Input.GetKey(GoTo.Up) || Input.GetKey(GoTo.Down)))
        {
            rBody.rotation = -90;
            rBody.velocity = new Vector2(horiz + speed, vert);
            trackStart();
        }
        else if (Input.GetKeyDown(GoTo.Fire))
        {
        }
        else
        {
            rBody.velocity = new Vector2(horiz, vert);
            trackStop();
        }



    }
    void trackStart()
    {
        trackLeft.animator.SetBool("isMoving", true);
        trackRight.animator.SetBool("isMoving", true);
    }

    void trackStop()
    {
        trackLeft.animator.SetBool("isMoving", false);
        trackRight.animator.SetBool("isMoving", false);
    }
}
