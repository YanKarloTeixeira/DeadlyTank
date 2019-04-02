﻿/*
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
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Player1Points: MonoBehaviour
{
    private Text PlayerPointsText;

    // Start is called before the first frame update
    void Awake()
    {
        PlayerPointsText = GetComponent<Text>();
    }

    public void UpdateUI(int value)
    {
        PlayerPointsText.text = String.Format("{0:0.##}", value); 
    }
}
