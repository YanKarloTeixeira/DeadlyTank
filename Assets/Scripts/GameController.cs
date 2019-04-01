using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour
{
    public Scoreboard_UI Scoreboard_UI;
    //public GameObject ui_EndLevelPanel;

    private int itemCounter = 0;    // How many items I have picked up
    private int totalItemCount = 0; // How many items are in my level

    public int Player1Points; 
    public int Player2Points;
    public double Player1FuelLevel;
    public double Player2FuelLevel;
    private double player1Damage { get; set; }
    private double player2Damage { get; set; }


    // Start is called before the first frame update
    void Start()
    {
        Player1Points = 0;
        Player2Points = 0;
        Player1FuelLevel = 0;
        Player1FuelLevel = 0;
    }
    public void SetPlayer1Points()
    {
        ++Player1Points;
    }

    public void SetPlayer2Points()
    {
        ++Player2Points;
    }


   
    // Called when an item is picked up
    public void PickUpItem()
    {
        //ui_cherryCounter.UpdateUI(++itemCounter, totalItemCount);
    }

    public void LevelEnd()
    {
        //ui_EndLevelPanel.SetActive(true);
        //ui_EndLevelPanel.GetComponentInChildren<UI_CherryCounter>().UpdateUI(itemCounter, totalItemCount);
    }
}
