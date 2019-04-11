using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject Gas;
    public GameObject Speed;
    public GameObject Recover;
    public GameObject LandMine;
    public int GasQty=2;
    public int SpeedQty=2;
    public int RecoverQty=2;
    public int LandMineQty=7;
    public int GasFactor = 0;
    public int SpeedFactor = 0;
    public int RecoverFactor = 0;
    public int LandMineFactor = 0;


    System.Timers.Timer aTimer;
    public bool isVisible = false;
    public SpriteRenderer sprite = null;

    // Start is called before the first frame update
    void Start()
    {
        //aTimer = new System.Timers.Timer();
        //aTimer.Interval = Random.Range(10f, 15f);
        //sprite = PowerUp.GetComponent<GameController>()
        PowerUpCreation();
        // InvokeRepeating("InstantiatingPowerup", Random.Range(1.0f, 10.0f), )
        //CancelInvoke("InstantiatePowerup");
    }

    // Update is called once per frame
    void Update()
    {


    }

    private void OnTimedEvent(object sender, ElapsedEventArgs e)
    {
    }


    //private void InstantiatePowerup()
    //{
    //    // Instantiate the object
    

    //    // Determine location on my map
    //    // Map width, map height
    //    // myPowerup.transform.position
    //}

    private void PowerUpCreation()
    {
        for (int i = 0; i < 200; i++)
        {
            Instantiate(Gas, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)),Quaternion.identity);
        }
        
        // for (int i = 0; i < GasQty; i++) Invoke("InstantiateGasPowerup", UnityEngine.Random.Range(1.0f, 10.0f));
        //for (int i = 0; i < SpeedQty; i++) Invoke("InstantiateSpeedPowerup", UnityEngine.Random.Range(1.0f, 10.0f));
        //for (int i = 0; i < RecoverQty; i++) Invoke("InstantiateRecoverPowerup", UnityEngine.Random.Range(1.0f, 10.0f));
        //for (int i = 0; i < LandMineQty; i++) Invoke("InstantiateLandMinePowerup", UnityEngine.Random.Range(1.0f, 10.0f));



    }

    private void InstantiateGasPowerUp()
    {
        Vector3 v3 = new Vector3(0.01f,0.01f);
        GameObject gGasObj = Instantiate(Gas, v3, Quaternion.identity);
    }
}
