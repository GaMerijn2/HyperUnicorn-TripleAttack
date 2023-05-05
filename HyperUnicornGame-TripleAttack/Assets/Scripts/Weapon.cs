using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public GameObject my_Bullet;
    public Transform fire_From_Position;

    public float firePower = 20f;
    
    public void Fire()
    {
        GameObject projectile = Instantiate(my_Bullet, fire_From_Position.position, fire_From_Position.rotation);
        projectile.GetComponent<Rigidbody2D>().AddForce(fire_From_Position.up * firePower, ForceMode2D.Impulse);
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
