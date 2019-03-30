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
        private double x;
        private double y;

        private double Direction; // rotation on the screen

        private float Speed;
        private float OriginalSpeed; 
        private float NoFuelSpeed;

        private double FuelQty;// Amount of Initial Fuel
        private double FuelConsumption = 0.001; // Fuel Consumption Amount 


        public Tank(double Pos_x, double Pos_y)
        {
            if (Pos_y < 0) Direction = 180;
            OriginalSpeed = 1;
            Speed = OriginalSpeed;
            NoFuelSpeed = Speed * 0.250f;
            FuelQty = 100; 
            FuelConsumption = 0.001;
        }

        public void move(string movement)
        {
            switch (movement)
            {
                case "up":
                    y += Speed;
                    Direction = 0;
                    break;
                case "down":
                    y -= Speed;
                    Direction = 180;
                    break;
                case "left":
                    x -= Speed;
                    Direction = 270;
                    break;
                case "right":
                    x += Speed;
                    Direction = 90;
                    break;
            }

        }

        public void setFuel(double PowerUp =0)
        {
            FuelQty += PowerUp - FuelConsumption;
            if (FuelQty < 0)
            {
                Speed = NoFuelSpeed;
                FuelQty = 0;
            }
        }


    }
}

