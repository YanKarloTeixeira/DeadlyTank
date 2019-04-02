﻿using System.Collections;
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

    void Start()
    {
        gCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
        Tank01 = GameObject.FindGameObjectWithTag("Player1").GetComponent<Player1>().Tank;
        Tank02 = GameObject.FindGameObjectWithTag("Player2").GetComponent<Player2>().Tank;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if 'other' is a tagged an item
        Debug.Log("Other tag: "+ other.tag);
        Debug.Log("Bullet trigger: " + this.trigger);
        if (other.tag == this.trigger) return;
        switch (other.tag)
        {
            case "Barrier":
                Debug.Log(other.ToString());
                Debug.Log("Barrier is gone");
                Instantiate(brick2, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                break;
            case "Barrier2":
                Debug.Log(other.ToString());
                Debug.Log("Barrier2 is gone");
                Instantiate(brick3, other.transform.position, other.transform.rotation);
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                break;
            case "Barrier3":
                Debug.Log(other.ToString());
                Debug.Log("Barrier3 is gone");
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                break;
            case "Player1":
                gCont.SetPlayer2Points();
                Debug.Log("Player 2 : " + gCont.Player2Points);
                Destroy(this.gameObject);
                Tank01.SetDamage();
                break;
            case "player2":
                gCont.SetPlayer1Points();
                Debug.Log("Player 1 : " + gCont.Player1Points);
                Destroy(this.gameObject);
                Tank02.SetDamage();
                break;
        }
        //if (other.CompareTag("Barrier"))
        //{
        //    Debug.Log("It is colliding");
        //    // Pick up the item
        //    // cherryCounter++;
        //    //gCont.PickUpItem();
        //    // Instantiate the item feedback object
        //    //Instantiate(itemFeedbackPref, other.transform.position, other.transform.rotation);
        //} 
    }
}
