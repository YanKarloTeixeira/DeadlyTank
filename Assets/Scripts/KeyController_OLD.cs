using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Objects;

public class KeyControllerOld : MonoBehaviour
{
    public KeyControllerOld(int player = 1)
    {

    }
    //PUBLIC VARIABLES
    public float speed = 1f;
    public float jumpForce = 500;


    //Players
    public Tank TankPlayer1;
    public Tank TankPlayer2;


    /**
    *  Key set for PLAYER1 control
    **/
    public KeyCode Key_P1_Up = KeyCode.UpArrow;
    public KeyCode Key_P1_Down = KeyCode.DownArrow;
    public KeyCode Key_P1_Left = KeyCode.LeftArrow;
    public KeyCode Key_P1_Right = KeyCode.RightArrow;
    public KeyCode Key_P1_Fire = KeyCode.Space;

    /**
    *  Key set for PLAYER2 control
    **/
    public KeyCode Key_P2_Up = KeyCode.W;
    public KeyCode Key_P2_Down = KeyCode.S;
    public KeyCode Key_P2_Left = KeyCode.A;
    public KeyCode Key_P2_Right = KeyCode.D;
    public KeyCode Key_P2_Fire = KeyCode.Q;

    //PRIVATE VARIABLES
    private Rigidbody2D rBody;

    // Reserved function. Run only once when the object is /// <summary>
    // User for initialization.
    void Start(){
        rBody = GetComponent<Rigidbody2D>();
       
    }
    void Update(){
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //rBody.AddForce(new Vector2(0,jumpForce));
            
        }
    }

    ///<summary>
    /// This function is called every framerate frame, if the monobehaviour is private void OnFailedToConnect(NetworkConnectionError error) {
    /// Use FixedUpdate for Physics-based movement only.!--
    ///</summary>
    
    void FixedUpdate(){
        speed = 1f;
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");
        //System.Console.WriteLine("horiz: " + horiz + "  vert: " + vert);
        //rBody.velocity = new Vector2(horiz * speed, vert * speed);
        if (Input.GetKeyDown(Key_P1_Up))
        {
            rBody.velocity = new Vector2(horiz, vert + speed);
            //rBody.MovePosition(new Vector2(horiz, vert + speed));
        }
        else if (Input.GetKeyDown(Key_P1_Down))
        {
            rBody.velocity = new Vector2(horiz, vert - speed);
        }
        else if (Input.GetKeyDown(Key_P1_Left))
        {
            rBody.velocity = new Vector2(horiz-speed, vert);
        }
        else if (Input.GetKeyDown(Key_P1_Right))
        {
            rBody.velocity = new Vector2(horiz + speed, vert);
        }
        else
        {
            //rBody.velocity = new Vector2(0f, 0f);
            rBody.velocity = new Vector2(horiz, vert);
        }



    }
}
