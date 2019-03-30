using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletMover : MonoBehaviour
{
    public float speed = 20.0f;
    Rigidbody2D rBody;
    // Start is called before the first frame update
    void Start()
    {
        Destroy(this.gameObject, 1.0f);
    }
}
