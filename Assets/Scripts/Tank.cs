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

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Assets.Scripts.Objects
{
    public class Tank
    {

        private double Damage; // From 0 to 150
        private double TotalDamageAllowed;
        private float Speed;
        private float InitialSpeed; 
        private double FuelQty;// Amount of Initial Fuel
        private double FuelConsumption = 0.001; // Fuel Consumption Amount 
        public string Flag;
        public int Points;
        public int TotalPoints;

        //private GameController gCont;

        public Tank(string Flag)
        {
            //gCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
            InitialSpeed = 3.0f;
            Speed = InitialSpeed;
            FuelQty = 100; 
            FuelConsumption = 0.01;
            Damage = 0;
            TotalDamageAllowed = 15;
            this.Flag = Flag;
            Points = 0;
            TotalPoints = 0;
        }

        public void TankLevelReset()
        {
            InitialSpeed = 3.0f;
            Speed = InitialSpeed;
            FuelQty = 100;
            FuelConsumption = 0.01;
            Damage = 0;
            TotalDamageAllowed = 15;
            Points = 0;

        }
        //public void UpdateScoreBoard()
        //{
        //    gCont.setScoreboard(this.Flag);
        //}
        public void Move(string movement)
        {
            ConsumeFuel();
        }

        public void ConsumeFuel()
        {
            FuelQty -= FuelConsumption;
        }

        public float GetSpeed()
        {
            if (Damage / TotalDamageAllowed >= 0.8) Speed = InitialSpeed * 0.2f;
            else if (Damage / TotalDamageAllowed >= 0.6) Speed = InitialSpeed * 0.4f;
            else if (Damage / TotalDamageAllowed >= 0.4) Speed = InitialSpeed * 0.6f;
            else if (Damage / TotalDamageAllowed >= 0.2) Speed = InitialSpeed * 0.8f;

            if (FuelQty <= 0) Speed = InitialSpeed * 0.1f;
            ConsumeFuel();
            return Speed;
        }

        public void SetDamage()
        {
            Damage++;
        }
        public double GetDamageLevel()
        {
            return Damage / TotalDamageAllowed ;
        }
        public void setFuel(double PowerUp =0)
        {
            FuelQty += (PowerUp - FuelConsumption);
        }
        public double GetFuel()
        {
            return FuelQty;
        }

        public string getFlag()
        {
            return this.Flag;
        }

        public void ScorePoints(int value=1)
        {
            Points += value;
            TotalPoints += value;
        }
        public int getScoredPoints(int value = 1)
        {
            return Points;
        }
        public int getTotalScoredPoints(int value = 1)
        {
            return TotalPoints;
        }
    }
}

