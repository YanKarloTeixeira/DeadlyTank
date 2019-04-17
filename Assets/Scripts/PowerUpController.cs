using System;
using System.Collections;
using System.Collections.Generic;
using System.Timers;
using UnityEngine;

public class PowerUpController : MonoBehaviour
{
    public GameObject Fuel;
    public GameObject Speed;
    public GameObject Repair;
    public GameObject LandMine;

    // PowerUp timers
    //private System.Timers.Timer aTimer;
    private System.Timers.Timer FuelTimer;
    private System.Timers.Timer SpeedTimer;
    private System.Timers.Timer RepairTimer;
    private System.Timers.Timer LandMineTimer;

    // Random Interval choice in secs
    public int FuelMinSecsInterval = 10;
    public int FuelMaxSecsInterval = 30;
    public int SpeedMinSecsInterval = 10;
    public int SpeedMaxSecsInterval = 30;
    public int RepairMinSecsInterval = 10;
    public int RepairMaxSecsInterval = 30;
    public int LandMineMinSecsInterval = 10;
    public int LandMineMaxSecsInterval = 30;

    // Max powerups qty allowed
    public int FuelMaxQtyAllowed = 2;
    public int SpeedMaxQtyAllowed = 1;
    public int RepairMaxQtyAllowed = 2;
    public int LandMineMaxQtyAllowed = 8;

    // Actual qty
    private int FuelQty = 0;
    private int SpeedQty = 0;
    private int RepairQty = 0;
    private int LandMineQty = 0;

    //public bool isVisible = false;
    //public SpriteRenderer sprite = null;
    //System.Timers.Timer aTimer  new System.Timers.Timer()

    // Start is called before the first frame update
    void Start()
    {
        FuelTimer = new System.Timers.Timer();
        SpeedTimer = new System.Timers.Timer();
        RepairTimer = new System.Timers.Timer();
        LandMineTimer = new System.Timers.Timer();

        //aTimer.Elapsed += new ElapsedEventHandler(OnTimedEvent);
        FuelTimer.Elapsed += new ElapsedEventHandler(FuelOnTimedEvent);
        SpeedTimer.Elapsed += new ElapsedEventHandler(SpeedOnTimedEvent);
        RepairTimer.Elapsed += new ElapsedEventHandler(RepairOnTimedEvent);
        LandMineTimer.Elapsed += new ElapsedEventHandler(LandMineOnTimedEvent);

        FuelMinSecsInterval = FuelMinSecsInterval * 1000;
        FuelMaxSecsInterval = FuelMaxSecsInterval * 1000;
        SpeedMinSecsInterval = SpeedMinSecsInterval * 1000;
        SpeedMaxSecsInterval = SpeedMaxSecsInterval * 1000;
        RepairMinSecsInterval = RepairMinSecsInterval * 1000;
        RepairMaxSecsInterval = RepairMaxSecsInterval * 1000;
        LandMineMinSecsInterval = LandMineMinSecsInterval * 1000;
        LandMineMaxSecsInterval = LandMineMaxSecsInterval * 1000;

        //aTimer.Interval = UnityEngine.Random.Range(10000,30000); // 10 seconds
        FuelTimer.Interval = UnityEngine.Random.Range(FuelMinSecsInterval, FuelMaxSecsInterval); ; // 10 seconds
        SpeedTimer.Interval = UnityEngine.Random.Range(SpeedMinSecsInterval, SpeedMaxSecsInterval); ; // 10 seconds
        RepairTimer.Interval = UnityEngine.Random.Range(RepairMinSecsInterval, RepairMaxSecsInterval); ; // 10 seconds
        LandMineTimer.Interval = UnityEngine.Random.Range(LandMineMinSecsInterval, LandMineMaxSecsInterval); ; // 10 seconds

        //aTimer = new System.Timers.Timer();
        //aTimer.Interval = Random.Range(10f, 15f);
        //sprite = PowerUp.GetComponent<GameController>()
        //PowerUpCreation();
        // InvokeRepeating("InstantiatingPowerup", Random.Range(1.0f, 10.0f), )
        //CancelInvoke("InstantiatePowerup");
    }

    // Update is called once per frame
    void Update()
    {
        FuelQty = GameObject.FindGameObjectsWithTag("Fuel").Length;
        if (FuelQty < FuelMaxQtyAllowed)
        {
            if(UnityEngine.Random.Range(1,100)>70)
            Instantiate(Fuel, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);
        }
        SpeedQty = GameObject.FindGameObjectsWithTag("Speed").Length;
        if (SpeedQty < SpeedMaxQtyAllowed)
        {
            if (UnityEngine.Random.Range(1, 100) > 90)
                Instantiate(Speed, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);
        }
        RepairQty = GameObject.FindGameObjectsWithTag("Repair").Length;
        if (RepairQty < RepairMaxQtyAllowed)
        {
            if (UnityEngine.Random.Range(1, 100) > 90)
                Instantiate(Repair, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);
        }
        LandMineQty = GameObject.FindGameObjectsWithTag("LandMine").Length;
        if (LandMineQty < LandMineMaxQtyAllowed)
        {
            if (UnityEngine.Random.Range(1, 100) > 30)
                Instantiate(LandMine, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);
        }


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
        Instantiate(Fuel, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);
        Instantiate(LandMine, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);
        Instantiate(Speed, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);
        Instantiate(Repair, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);

        // for (int i = 0; i < FuelQty; i++) Invoke("InstantiateGasPowerup", UnityEngine.Random.Range(1.0f, 10.0f));
        //for (int i = 0; i < SpeedQty; i++) Invoke("InstantiateSpeedPowerup", UnityEngine.Random.Range(1.0f, 10.0f));
        //for (int i = 0; i < RepairQty; i++) Invoke("InstantiateRecoverPowerup", UnityEngine.Random.Range(1.0f, 10.0f));
        //for (int i = 0; i < LandMineQty; i++) Invoke("InstantiateLandMinePowerup", UnityEngine.Random.Range(1.0f, 10.0f));



    }

    private void FuelOnTimedEvent(object sender, ElapsedEventArgs e)
    {
        int qtd = GameObject.FindGameObjectsWithTag("Fuel").Length;
        if (qtd >= FuelMaxQtyAllowed) return;
        Instantiate(Fuel, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);
    }

    private void SpeedOnTimedEvent(object sender, ElapsedEventArgs e)
    {
        int qtd = GameObject.FindGameObjectsWithTag("Speed").Length;
        if (qtd >= SpeedMaxQtyAllowed) return;
        Instantiate(Speed, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);
    }

    private void RepairOnTimedEvent(object sender, ElapsedEventArgs e)
    {
        int qtd = GameObject.FindGameObjectsWithTag("Repair").Length;
        if (qtd >= RepairMaxQtyAllowed) return;
        Instantiate(Repair, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);
    }

    private void LandMineOnTimedEvent(object sender, ElapsedEventArgs e)
    {
        int qtd = GameObject.FindGameObjectsWithTag("LandMine").Length;
        if (qtd >= LandMineMaxQtyAllowed) return;
        Instantiate(LandMine, new Vector3(UnityEngine.Random.Range(-9.0f, 9.0f), UnityEngine.Random.Range(-3, 3)), Quaternion.identity);
    }

    private void InstantiateGasPowerUp()
    {
        Vector3 v3 = new Vector3(0.01f,0.01f);
        GameObject gGasObj = Instantiate(Fuel, v3, Quaternion.identity);
    }
}
