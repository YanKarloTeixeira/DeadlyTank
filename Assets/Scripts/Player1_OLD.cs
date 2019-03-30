using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Assets.Scripts.Objects;
using System;

public class Player1_OLD : MonoBehaviour
{
    //PUBLIC VARIABLES
    public float speed = 1f;
    public float jumpForce = 500;

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
        rBody = GameObject.FindGameObjectWithTag("Tank01").GetComponent<Rigidbody2D>();
        GoTo = new KeyController(1);
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
        float horiz = Input.GetAxis("Horizontal");
        float vert = Input.GetAxis("Vertical");



        if (Input.GetKey(GoTo.Up))
        {
            rBody.rotation = 0;
            rBody.velocity = new Vector2(horiz, vert + speed);
            trackStartOLD();
        }
        //else if (Input.GetKeyDown(GoTo.Down) || Input.GetKey(GoTo.Down))
        else if (Input.GetKey(GoTo.Down))
        {
            rBody.rotation = 180;
            //transform.rotation.SetEulerAngles(0f, 0f, z: 180f - transform.rotation.z);
            rBody.velocity = new Vector2(horiz, vert - speed);
            trackStartOLD();
        }
        //else if (Input.GetKeyDown(GoTo.Left) || Input.GetKey(GoTo.Left))
        else if (Input.GetKey(GoTo.Left) && !(Input.GetKey(GoTo.Up) || Input.GetKey(GoTo.Down)))
        {
            rBody.rotation = 90;
            //transform.rotation.SetEulerAngles(0f,0f, z: 90f -transform.rotation.z);
            rBody.velocity = new Vector2(horiz - speed, vert);
            trackStartOLD();
        }
        //else if (Input.GetKeyDown(GoTo.Right) || Input.GetKey(GoTo.Right))
        else if (Input.GetKey(GoTo.Right) && !(Input.GetKey(GoTo.Up) || Input.GetKey(GoTo.Down)))
        {
            rBody.rotation = 270;
            //transform.rotation.SetEulerAngles(0f,0f, z: 90f -transform.rotation.z);
            rBody.velocity = new Vector2(horiz + speed, vert);
            trackStartOLD();
        }
        else if (Input.GetKeyDown(GoTo.Fire))
        {
        }
        else
        {
            rBody.velocity = new Vector2(horiz, vert);
            trackStopOLD();
        }



    }
    void trackStartOLD()
    {
        trackLeft.animator.SetBool("isMoving", true);
        trackRight.animator.SetBool("isMoving", true);
    }

    void trackStopOLD()
    {
        trackLeft.animator.SetBool("isMoving", false);
        trackRight.animator.SetBool("isMoving", false);
    }
}
