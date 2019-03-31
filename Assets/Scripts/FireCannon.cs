﻿using System.Collections;
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
        temp = new Vector3(0.0f, bulletSpawn.position.y+0.1f, 0.0f); 
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GameObject gObj = Instantiate(bullet, bulletSpawn.position+temp, bulletSpawn.rotation);
            gObj.GetComponent<Rigidbody2D>().velocity = bulletSpawn.up * 10.0f;
        }
    }
}
