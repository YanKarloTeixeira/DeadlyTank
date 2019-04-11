using Assets.Scripts.Objects;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour
{
    public string trigger;
    private GameController gCont;
    private Assets.Scripts.Objects.Tank Tank01, Tank02;
    public GameObject Tank01_;
    public int effect = 0;
    public int type = 0;

    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject,Random.Range(10f,15f));
    }

    // Update is called once per frame
    void Update()
    {

        
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if 'other' is a tagged an item
        Debug.Log("Other tag: " + other.tag);
        Debug.Log("Bullet trigger: " + this.trigger);
        if (other.tag == this.trigger) return;
        switch (other.tag.ToUpper())
        {
            case "PLAYER1" :

                Tank02.ScorePoints();
                Tank01.SetDamage();
                gCont.setScoreboard(Tank02.Flag);
                Destroy(this.gameObject);
                break;
            case "PLAYER2":
                Tank01.ScorePoints();
                Tank02.SetDamage();
                gCont.setScoreboard(Tank01.Flag);
                Destroy(this.gameObject);
                break;
        }
    }

    void PowerUpEffect(Tank tankTrigger, Tank tankOpponent)
    {
        switch (type)
        {
            case 1: // gas
                tankTrigger.setFuel(tankTrigger.GetFuel()+effect);
                break;
        }
    }

}
