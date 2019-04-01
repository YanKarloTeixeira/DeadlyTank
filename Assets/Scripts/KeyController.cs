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
using Assets.Scripts.Objects;

public class KeyController   
{
    public KeyCode Up;
    public KeyCode Down;
    public KeyCode Left;
    public KeyCode Right;
    public KeyCode Fire;

    public KeyController(int player = 1)
    {
        if (player == 2)
        {
            Up = KeyCode.W;
            Down = KeyCode.S;
            Left = KeyCode.A;
            Right = KeyCode.D;
            Fire = KeyCode.Q;
        }
        else
        {
            Up = KeyCode.UpArrow;
            Down = KeyCode.DownArrow;
            Left = KeyCode.LeftArrow;
            Right = KeyCode.RightArrow;
            Fire = KeyCode.Space;
        }
    }

    public Vector2 movement( float horiz, float vert, float speed)

    {
        if (Input.GetKeyDown(this.Up))
        {
            vert += speed;
         }
        else if (Input.GetKeyDown(this.Down))
        {
            vert -= speed;
        }
        else if (Input.GetKeyDown(this.Left))
        {
            horiz -= speed;
        }
        else if (Input.GetKeyDown(this.Right))
        {
            horiz += speed;
        }
        return new Vector2(horiz, vert);



    }
}
