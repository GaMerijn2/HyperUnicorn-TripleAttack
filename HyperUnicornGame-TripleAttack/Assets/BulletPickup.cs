using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletPickup : MonoBehaviour
{
    int bulletAmount;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            bulletAmount = collision.gameObject.GetComponent<Player_Movement>().MyBullets;

            if(bulletAmount <= 2)
            {
                collision.gameObject.GetComponent<Player_Movement>().MyBullets++;
                Destroy(gameObject);
            }
            else
            {
                Destroy(gameObject);
            }
            
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
