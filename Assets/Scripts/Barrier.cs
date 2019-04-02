using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrier : MonoBehaviour
{
    public int Damage=0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void setDamage()
    {
        Damage++;
        renderDamage(Damage);
    }

    public int getDamage()
    {
        return Damage;
    }

    public void renderDamage(int value)
    {

    }
}
