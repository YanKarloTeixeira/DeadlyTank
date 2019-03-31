using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BulletInventory : MonoBehaviour
{
    public GameObject itemFeedbackPref;

    private GameController gCont;

    void Start()
    {
        gCont = GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Check if 'other' is a tagged an item
        Debug.Log(other.tag);
        switch (other.tag)
        {
            case "Barrier":
                Debug.Log("Barrier is gone");
                Destroy(other.gameObject);
                Destroy(this.gameObject);
                break;
            case "Player1":
                gCont.SetPlayer2Points();
                Debug.Log("Player 2 : " + gCont.Player2Points);
                Destroy(this.gameObject);
                break;
            case "player2":
                gCont.SetPlayer1Points();
                Debug.Log("Player 1 : " + gCont.Player1Points);
                Destroy(this.gameObject);
                break;
        }
        //if (other.CompareTag("Barrier"))
        //{
        //    Debug.Log("It is colliding");
        //    // Pick up the item
        //    // cherryCounter++;
        //    //gCont.PickUpItem();
        //    // Instantiate the item feedback object
        //    //Instantiate(itemFeedbackPref, other.transform.position, other.transform.rotation);
        //} 
    }
}
