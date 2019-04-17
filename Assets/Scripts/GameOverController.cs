using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOverController : MonoBehaviour
{
    public int pl=0;    
    
    // Start is called before the first frame update
    /* void Start()
    {
        if(pl==1)
            ((Text)GameObject.FindGameObjectWithTag("result").GetComponent<Text>()).text = "PLAYER 1 WIN";
            else
            {((Text)GameObject.FindGameObjectWithTag("result").GetComponent<Text>()).text = "PLAYER 2 WIN";
                
            }
    }*/
    public void StartGame()
    {
         SceneManager.LoadScene("Battle1");
    }

    
}
