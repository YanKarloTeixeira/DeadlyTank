using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireCannon : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletSpawn;
    public Vector3 temp;
    public Vector3 position;
    public Quaternion rotation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject gObj = Instantiate(bullet, bulletSpawn.position, bulletSpawn.rotation);
            gObj.GetComponent<Rigidbody2D>().velocity = bulletSpawn.up * 5.0f;
        }
    }
}
