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
    public int Player1Fuel;
    public int Player2Fuel;
    public int Player1FuelConsumption;
    public int Player2FuelConsumption;

    // Start is called before the first frame update
    void Start()
    {
        // GameObject.Find("UI_CherryCounter").GetComponent<UI_CherryCounter>();
        //totalItemCount = GameObject.FindGameObjectsWithTag("Item").Length;
        //ui_cherryCounter.UpdateUI(itemCounter, totalItemCount);
        Player1Points = 0;
        Player2Points = 0;
        Player1Fuel = 0;
        Player1Fuel = 0;
        Player1FuelConsumption = 1;
        Player1FuelConsumption = 1;
    }
    public void SetPlayer1Points()
    {
        ++Player1Points;
    }

    public void SetPlayer2Points()
    {
        ++Player2Points;
    }

    public void SetPlayer1Fuel()
    {
        Player1Fuel -= Player1FuelConsumption;
    }

    public void SetPlayer2Fuel()
    {
        Player2Fuel -= Player2FuelConsumption;
    }

    public void SetPlayer1FuelConsumption(int NewFuelConsumption)
    {
        Player1FuelConsumption = NewFuelConsumption;
    }

    public void SetPlayer2FuelConsumption(int NewFuelConsumption)
    {
        Player2FuelConsumption = NewFuelConsumption;
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
