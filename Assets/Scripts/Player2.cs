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
    public Track trackLeft;
    public Track trackRight;
    public Tank Tank;
    private Tank OtherTank;
    public string playerTag = "Player2";
    public string OtherPlayerTag = "Player1";
    //public float speed = 1f;
    public float jumpForce = 500;
    public int Fuel = 100000;

    //Players
    public KeyController GoTo;
    public float horiz = 0.0f;
    public float vert = 0.0f;

    //PRIVATE VARIABLES
    private Rigidbody2D rBody;
    private GameController gCont;

    // Bullet Variables
    public GameObject bullet;
    public Transform bulletSpawn;
    public Vector3 temp;
    public Vector3 position;
    public Quaternion rotation;

    //PowerUps Tags
    public string FuelTag = "Fuel";
    public string LandMineTag = "LandMine";
    public string SpeedTag = "Speed";
    public string RepairTag = "Life";

    //PowerUps Effescts Variables
    public int LandMineDamage;
    public int LandMineOpponentPoints;
    public int Repair;
    public float SpeedUP;
    public double FuelUp;
    // Reserved function. Run only once when the object is /// <summary>
    // User for initialization.
    void Start()
    {
        Tank = new Tank(playerTag);
        OtherTank = GameObject.FindGameObjectWithTag(OtherPlayerTag).GetComponent<Player1>().Tank;

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


    void FixedUpdate()
    {

        // Blocks movements after end of level
        //if (gCont.Player1Points[gCont.ActualLevel-1] >= 15 || gCont.Player2Points[gCont.ActualLevel-1] >= 15) return;

        //Movements Mapping from keyboard
        if (Input.GetKey(GoTo.Up) && Input.GetKey(GoTo.Left))
        {
            rBody.rotation = 45;
            rBody.velocity = new Vector2(horiz - Tank.GetSpeed(), vert + Tank.GetSpeed());
            trackStart();
        }
        else if (Input.GetKey(GoTo.Up) && Input.GetKey(GoTo.Right))
        {
            rBody.rotation = -45;
            rBody.velocity = new Vector2(horiz + Tank.GetSpeed(), vert + Tank.GetSpeed());
            trackStart();
        }
        else if (Input.GetKey(GoTo.Down) && Input.GetKey(GoTo.Left))
        {
            rBody.rotation = 135;
            rBody.velocity = new Vector2(horiz - Tank.GetSpeed(), vert - Tank.GetSpeed());
            trackStart();
        }
        else if (Input.GetKey(GoTo.Down) && Input.GetKey(GoTo.Right))
        {
            rBody.rotation = -135;
            rBody.velocity = new Vector2(horiz + Tank.GetSpeed(), vert - Tank.GetSpeed());
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

        setScoreBoard();

    }// End of FixedUpdate()


    void trackStart()
    {
        //trackLeft.animator.SetBool("isMoving", true);
        //trackRight.animator.SetBool("isMoving", true);
        Tank.setFuel();
    }

    void trackStop()
    {
        //trackLeft.animator.SetBool("isMoving", false);
        //trackRight.animator.SetBool("isMoving", false);
    }

    int GetTankPoints()
    {
        return Tank.getScoredPoints();
    }

    void setScoreBoard()
    {
        gCont.setScoreboard(Tank.Flag);
    }

    //void OnTriggerEnter2D(Collider2D other)
    //{
    //    // Check if 'other' is a tagged an item
    //    if(other.tag.ToUpper() == LandMineTag.ToUpper()){
    //        OtherTank = GameObject.FindGameObjectWithTag(OtherPlayerTag).GetComponent<Player2>().Tank;
    //        Debug.Log("Land Mine explodes !!!");
    //        OtherTank.ScorePoints(LandMineOpponentPoints);
    //        Tank.SetDamage(LandMineDamage);
    //        gCont.setScoreboard(OtherTank.Flag);
    //        Destroy(other.gameObject);
    //    }
    //    else if(other.tag.ToUpper() == FuelTag.ToUpper())
    //    {
    //        Debug.Log("FUEL AVAILABLE !!!");
    //        Tank.setFuel(FuelUp);
    //        Destroy(other.gameObject);
    //    }
    //    else if (other.tag.ToUpper() == RepairTag.ToUpper())
    //    {
    //        Debug.Log("MECHANICS WORKING !!!");
    //        Tank.SetDamage(Repair*(-1));
    //        Destroy(other.gameObject);
    //    }
    //    else {
    //        // available for points powerUp
    //    }


    //    //{
    //    //    case  LandMineTag.ToString():
    //    //        OtherTank = GameObject.FindGameObjectWithTag(OtherPlayerTag).GetComponent<Player2>().Tank;
    //    //        Debug.Log("Land Mine explodes !!!" );
    //    //        OtherTank.ScorePoints();
    //    //        Tank.SetDamage();
    //    //        gCont.setScoreboard(OtherTank.Flag);
    //    //        Destroy(other.gameObject);
    //    //        break;
    //    //    case "GAS":
    //    //        Debug.Log("FUEL AVAILABLE !!!");
    //    //        Tank.setFuel(30);
    //    //        gCont.setScoreboard(OtherTank.Flag);
    //    //        Destroy(other.gameObject);
    //    //        break;
    //    //}
    //}
}
