using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int speed;
    public int damage;

    public void GetHit()
    {
        health -= 1;
        if(health == 0)
        {
            Destroy(gameObject);
        }
    }
    void HuntingPlayer()
    {

    }
    

    // Update is called once per frame
    void Update()
    {
        
    }
}
