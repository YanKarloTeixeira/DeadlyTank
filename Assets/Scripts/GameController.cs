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

public class GameController : MonoBehaviour
{
    public Scoreboard_UI Scoreboard_UI;
    private Assets.Scripts.Objects.Tank Tank01;
    private Assets.Scripts.Objects.Tank Tank02;

    //private int itemCounter = 0;    // How many items I have picked up
    //private int totalItemCount = 0; // How many items are in my level

    public int ActualLevel = 1;
    public int[] Player1Points = { 0, 0, 0 };
    public int[] Player2Points = { 0, 0, 0 };
    public double Player1FuelLevel = 0;
    public double Player2FuelLevel = 0;
    public double player1Damage = 0;
    public double player2Damage = 0;

    public Player1 player1;
    public Player2 player2;

    public UI_Player1Points UI_Player1Points;
    public UI_Player1Fuel UI_Player1Fuel;
    public UI_Player1Damage UI_Player1Damage;

    public UI_Player2Points UI_Player2Points;
    public UI_Player2Fuel UI_Player2Fuel;
    public UI_Player2Damage UI_Player2Damage;

    //public Text ScoreboardPlayer1Fuel;
    //public Text ScoreboardPlayer1Damage;

    //public Text ScoreboardPlayer2Points;
    //public Text ScoreboardPlayer2Fuel;
    //public Text ScoreboardPlayer2Damage;

    // Start is called before the first frame update

    void Start()
    {
        /******************************
         Initializing the Scoreboard
         ******************************/
        //UI_Player1Points.UpdateUI(player1.Tank.getScoredPoints());
        //UI_Player1Fuel.UpdateUI(player1.Tank.GetFuel());
        //UI_Player1Damage.UpdateUI(player1.Tank.GetDamageLevel());

        //UI_Player2Points.UpdateUI(player2.Tank.getScoredPoints());
        //UI_Player2Fuel.UpdateUI(player2.Tank.GetFuel());
        //UI_Player2Damage.UpdateUI(player2.Tank.GetDamageLevel());

        /*****************************************************************/
    }

    // Updates the player1 scoreboard
    private void setScoreboard1()
    {
        UI_Player1Points.UpdateUI(player1.Tank.getScoredPoints());
        UI_Player1Fuel.UpdateUI(player1.Tank.GetFuel());
        UI_Player1Damage.UpdateUI(player1.Tank.GetDamageLevel());
    }

    // Updates the player2 scoreboard
    private void setScoreboard2()
    {
        UI_Player2Points.UpdateUI(player2.Tank.getScoredPoints());
        UI_Player2Fuel.UpdateUI(player2.Tank.GetFuel());
        UI_Player2Damage.UpdateUI(player2.Tank.GetDamageLevel());
    }


    /**********************************************
     Directs the scoreboard update 
     according to the tank which trigged it
     **********************************************/
    public void setScoreboard(string Flag = null)
    {
        if (Flag == player1.Tank.getFlag())
            setScoreboard1();
        else
            setScoreboard2();
        UpdateHistorical();
    }
    /**/


    /**************************************
     Local variables Update for keep the
     information after game level changing
     **************************************/
    public void UpdateHistorical()
    {
        Debug.Log("=======================================================================================>" + ActualLevel);
        Player1Points[ActualLevel - 1] = player1.Tank.getScoredPoints();
        Player2Points[ActualLevel - 1] = player2.Tank.getScoredPoints();
        Player1FuelLevel = player1.Tank.GetFuel();
        Player2FuelLevel = player2.Tank.GetFuel();
        player1Damage = player1.Tank.GetDamageLevel();
        player2Damage = player2.Tank.GetDamageLevel();
    }

    // Update the level
    public void ChangeLevel()
    {
        ++ActualLevel;
    }

    // Called when an item is picked up
    public void PickUpItem()
    {
        //ui_cherryCounter.UpdateUI(++itemCounter, totalItemCount);
    }

    // Calculates the Total Score so far
    public int Player1TotalScore()
    {
        int value = 0;
        for (int i = 0; i < 3; i++)
        {
            value += Player1Points[i];
        }
        return value;
    }

    public int Player2TotalScore()
    {
        int value = 0;
        for (int i = 0; i < 3; i++)
        {
            value += Player2Points[i];
        }
        return value;
    }
    public void LevelEnd()
    {
        //ui_EndLevelPanel.SetActive(true);
        //ui_EndLevelPanel.GetComponentInChildren<UI_CherryCounter>().UpdateUI(itemCounter, totalItemCount);
    }

}
