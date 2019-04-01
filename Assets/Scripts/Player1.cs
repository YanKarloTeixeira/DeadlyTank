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

public class Player1 : MonoBehaviour
{
    //PUBLIC VARIABLES
    public Track trackLeft;
    public Track trackRight;
    public string playerTag;
    //public float speed = 1f;
    public float jumpForce = 500;
    public int Fuel = 100000;
    public bool Moving_UP = false;
    public bool Moving_Down = false;
    public bool Moving_Left = false;
    public bool Moving_Right = false;

    //Players
    public KeyController GoTo;
    public Tank Tank;
    public float horiz=0.0f;
    public float vert =0.0f;

    //PRIVATE VARIABLES
    private Rigidbody2D rBody;
    
    // Bullet Variables
    public GameObject bullet;
    public Transform bulletSpawn;
    public Vector3 temp;
    public Vector3 position;
    public Quaternion rotation;
    private GameController gCont;

    // Reserved function. Run only once when the object is /// <summary>
    // User for initialization.
    void Start()
    {
        playerTag = "Player1";
        Tank = new Tank(playerTag);

        rBody = GameObject.FindGameObjectWithTag(playerTag).GetComponent<Rigidbody2D>();
        gCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();

        if (playerTag == "Player1")
        {
            GoTo = new KeyController(1);
            horiz = Input.GetAxis("Horizontal");
            vert = Input.GetAxis("Vertical");
        }
        else
        {
            GoTo = new KeyController(2);
            horiz = Input.GetAxis("Horizontal_P2");
            vert = Input.GetAxis("Vertical_P2");
        }
    }
    
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //rBody.AddForce(new Vector2(0,jumpForce));
            
        }
    }

    void FixedUpdate()
    {
        //speed = 1f;

        Moving_UP = Input.GetKey(GoTo.Up);
        Moving_Down = Input.GetKey(GoTo.Down);
        Moving_Left = Input.GetKey(GoTo.Left);
        Moving_Right = Input.GetKey(GoTo.Right);


        if(Input.GetKey(GoTo.Up) && Input.GetKey(GoTo.Left))
        {
            rBody.rotation = 45;
            rBody.velocity = new Vector2(horiz- Tank.GetSpeed(), vert + Tank.GetSpeed());
            trackStart();
        }
        else if (Input.GetKey(GoTo.Up) && Input.GetKey(GoTo.Right))
        {
            rBody.rotation = -45;
            rBody.velocity = new Vector2(horiz+ Tank.GetSpeed(), vert + Tank.GetSpeed());
            trackStart();
        }
        else if (Input.GetKey(GoTo.Down) && Input.GetKey(GoTo.Left))
        {
            rBody.rotation = 135;
            rBody.velocity = new Vector2(horiz- Tank.GetSpeed(), vert - Tank.GetSpeed());
            trackStart();
        }
        else if (Input.GetKey(GoTo.Down) && Input.GetKey(GoTo.Right))
        {
            rBody.rotation = -135;
            rBody.velocity = new Vector2(horiz+ Tank.GetSpeed(), vert - Tank.GetSpeed());
            trackStart();   
        }
        else if (Input.GetKey(GoTo.Up))
        {
            rBody.rotation = 0;
            rBody.velocity = new Vector2(horiz, vert + Tank.GetSpeed());
            trackStart();
        }
        else if (Input.GetKey(GoTo.Down))
        {
            rBody.rotation = 180;
            rBody.velocity = new Vector2(horiz, vert - Tank.GetSpeed());
            trackStart();
        }
        else if (Input.GetKey(GoTo.Left) && !(Input.GetKey(GoTo.Up) || Input.GetKey(GoTo.Down)))
        {
            rBody.rotation = 90;
            rBody.velocity = new Vector2(horiz - Tank.GetSpeed(), vert);
            trackStart();
        }
        else if (Input.GetKey(GoTo.Right) && !(Input.GetKey(GoTo.Up) || Input.GetKey(GoTo.Down)))
        {
            rBody.rotation = -90;
            rBody.velocity = new Vector2(horiz + Tank.GetSpeed(), vert);
            trackStart();
        }
        else
        {
            rBody.velocity = new Vector2(horiz, vert);
            trackStop();
        }

        if (Input.GetKeyDown(GoTo.Fire))
        {
            GameObject gObj = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            gObj.GetComponent<BulletInventory>().trigger = playerTag;
            gObj.GetComponent<Rigidbody2D>().velocity = bulletSpawn.up * 10.0f;
        }

        
    }// End of FixedUpdate()


    // This method is to be trigged by the bullet collision
    void SetDamage()
    {
        Tank.SetDamage();
    }



    void trackStart()
    {
        trackLeft.animator.SetBool("isMoving", true);
        trackRight.animator.SetBool("isMoving", true);
        Tank.ConsumeFuel();
        GameControllerUpdate();
        //Debug.Log(Tank.Flag + " fuel level is :" + gCont.Player1FuelLevel);

        //if(--Fuel<0)  speed = speed / 10;
    }

    void trackStop()
    {
        trackLeft.animator.SetBool("isMoving", false);
        trackRight.animator.SetBool("isMoving", false);
    }

    void GameControllerUpdate()
    {
        gCont.Player1FuelLevel= Tank.GetFuel();
    }
}
