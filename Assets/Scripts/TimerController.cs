using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class TimerController : MonoBehaviour
{
    private System.Timers.Timer aTimer;
    public int LevelDurationInMinutes = 1;
    public GameObject gameController;
    public bool endLevel = false;

    // Start is called before the first frame update
    void Start()
    {
        aTimer = new System.Timers.Timer();
        aTimer.Interval = LevelDurationInMinutes * 6000;
        aTimer.Elapsed += new System.Timers.ElapsedEventHandler(OnTimedEvent);
        aTimer.Start();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
        this.LevelEnd();
    }

    public void LevelEnd()
    {
        endLevel = true;
        Debug.Log("===============================(LEVEL END)================================");
        //ChangeLevel();
        //switch (ActualLevel)
        //{
        //    case 2:
        //        setPlayerPrefs();
        //        SceneManager.LoadScene("Battle2");
        //        break;
        //    case 3:
        //        setPlayerPrefs();
        //        SceneManager.LoadScene("Battle3");
        //        break;
        //    default:
        //        SceneManager.LoadScene("GameOver");
        //        break;

        //}
        //player1.Tank.ResetLevel();
        //player2.Tank.ResetLevel();

        ////ui_EndLevelPanel.SetActive(true);
        ////ui_EndLevelPanel.GetComponentInChildren<UI_CherryCounter>().UpdateUI(itemCounter, totalItemCount);
    }



}
