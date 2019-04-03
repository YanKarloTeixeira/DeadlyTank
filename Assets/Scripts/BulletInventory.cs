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

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletInventory : MonoBehaviour
{
    public string  trigger;
    private GameController gCont;
    private Assets.Scripts.Objects.Tank Tank01, Tank02;
    public GameObject brick2;
    public GameObject brick3;
    public GameObject rock2;
    public GameObject rock3;
    public GameObject metal2;
    public GameObject metal3;
    public int GameLevel;

    void Start()
    {
        gCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Tank01 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1>().Tank;
        Tank02 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2>().Tank;
        GameLevel = Tank01.GameLevel;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if 'other' is a tagged an item
        Debug.Log("Other tag: "+ other.tag);
        Debug.Log("Bullet trigger: " + this.trigger);
        if (other.tag == this.trigger) return;
        switch (other.tag.ToUpper())
        {
            case "BARRIER":

                if (GameLevel==1)
                Instantiate(brick2, other.transform.position, other.transform.rotation);
                else if(GameLevel==2)
                    Instantiate(rock2, other.transform.position, other.transform.rotation);
                else
                    Instantiate(metal2, other.transform.position, other.transform.rotation);


                Destroy(other.gameObject);
                Destroy(this.gameObject);
                break;
            case "BARRIER2":

                if (GameLevel == 1)
                    Instantiate(brick3, other.transform.position, other.transform.rotation);
                else if (GameLevel == 2)
                    Instantiate(rock3, other.transform.position, other.transform.rotation);
                else
                    Instantiate(metal3, other.transform.position, other.transform.rotation);


                Destroy(other.gameObject);
                Destroy(this.gameObject);
                break;
            case "BARRIER3":
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                break;
            case "PLAYER1":
                Tank02.ScorePoints();
                Tank01.SetDamage();
                gCont.setScoreboard(Tank02.Flag);
                Destroy(this.gameObject);
                break;
            case "PLAYER2":
                Tank01.ScorePoints();
                Tank02.SetDamage();
                gCont.setScoreboard(Tank01.Flag);
                Destroy(this.gameObject);
                break;
        }
    }
}
