using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int health;
    public int speed;
    public int damage;
    public Player_Movement player_Controller;

    public GameObject bulletPrefab;

    public void GetHit()
    {
        health -= 1;
        if(health == 0)
        {
            if(player_Controller.MyBullets <= 2)
            {
               GameObject myPickup = Instantiate(bulletPrefab, this.transform.position, this.transform.rotation);
            }
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
