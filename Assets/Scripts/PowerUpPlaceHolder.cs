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
public class PowerUpPlaceHolder : MonoBehaviour
{
    public string trigger;
    private GameController gCont;
    private Assets.Scripts.Objects.Tank Tank01, Tank02;
    public GameObject PowerUp1;
    public GameObject PowerUp2;
    public GameObject PowerUp3;
    public GameObject PowerUp4;

    public bool isColliding = false;

    void Start()
    {
        gCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Tank01 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1>().Tank;
        Tank02 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2>().Tank;
    }

    private void OnEnable()
    {
        float value = Random.Range(0f, 100.0f);
        switch (value)
        {
            case float n when (n < 25f):
                Instantiate(PowerUp1, this.transform.position, this.transform.rotation);
                break;
            case float n when (n < 50f):
                Instantiate(PowerUp2, this.transform.position, this.transform.rotation);
                break;
            case float n when (n < 75f):
                Instantiate(PowerUp3, this.transform.position, this.transform.rotation);
                break;
            default:
                Instantiate(PowerUp4, this.transform.position, this.transform.rotation);
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        isColliding = !other.tag.Contains("Player");
    }


}
