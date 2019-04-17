using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    private GameController gCont;
    public Assets.Scripts.Objects.Tank Tank01, Tank02;

    //PowerUps Tags
    public string FuelTag = "Fuel";
    public string LandMineTag = "LandMine";
    public string SpeedTag = "Speed";
    public string RepairTag = "Repair";

    //PowerUps Effescts Variables
    private int LandMineDamage=3;
    private int LandMineOpponentPoints=3;
    private int Repair=10;
    private float SpeedUP=0;
    private double FuelUp=50;



    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, Random.Range(10f, 15f));
        Tank01 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1>().Tank;
        Tank02 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2>().Tank;

    }

    // Update is called once per frame
    void Update()
    {


    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if 'other' is a tagged an item
        if (this.tag == LandMineTag) LandMineCollision(other.tag);
        else if (this.tag == SpeedTag) SpeedCollision(other.tag);
        else if (this.tag == FuelTag) FuelCollision(other.tag);
        else if (this.tag == RepairTag) RepairCollision(other.tag);


    }

    void LandMineCollision(string player)
    {
        Debug.Log("Land Mine explodes !!!");
        if (player == "Player1")
        {
            Tank02.ScorePoints(LandMineOpponentPoints);
            Tank01.SetDamage(LandMineDamage);
            Destroy(this.gameObject);
            this.UpdateScoreboard(player);

        }
        else if (player == "Player2")
        {
            Tank01.ScorePoints(LandMineOpponentPoints);
            Tank02.SetDamage(LandMineDamage);
            Destroy(this.gameObject);
            this.UpdateScoreboard(player);
        }

    }

    void SpeedCollision(string player)
    {
        Debug.Log("FUEL AVAILABLE !!!");
        if (player == "Player1")
        {
            Tank01.setFuel(FuelUp);
            Destroy(this.gameObject);
        }
        else if (player == "Player2")
        {
            Tank02.setFuel(FuelUp);
            Destroy(this.gameObject);
        }
    }

    void RepairCollision(string player)
    {
        Debug.Log("MECHANICS WORKING !!!");
        if (player == "Player1")
        {
            Tank01.SetDamage(Repair * (-1));
            Destroy(this.gameObject);
            this.UpdateScoreboard(player);
        }
        else if (player == "Player2")
        {
            Tank02.SetDamage(Repair * (-1));
            Destroy(this.gameObject);
            this.UpdateScoreboard(player);
        }
    }


    void FuelCollision(string player)
    {
        Debug.Log("FUEL AVAILABLE !!!");
        if (player == "Player1")
        {
            Tank01.setFuel(FuelUp);
            Destroy(this.gameObject);
            this.UpdateScoreboard(player);
        }
        else if (player == "Player2")
        {
            Tank02.setFuel(FuelUp);
            Destroy(this.gameObject);
            this.UpdateScoreboard(player);
        }
    }
    void UpdateScoreboard(string player)
    {
        (GameObject.FindGameObjectWithTag("GameController")
           .GetComponent<GameController>()).setScoreboard(player);

    }
}