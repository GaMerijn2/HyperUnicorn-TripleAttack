using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bullet : MonoBehaviour
{
    public Rigidbody2D bullet_body;

    
    // Start is called before the first frame update
    void Start()
    {
        bullet_body = this.GetComponent<Rigidbody2D>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        switch (collision.gameObject.tag)
        {
            case "Wall":
                Destroy(gameObject);
                break;
            case "Ghost":
                collision.gameObject.GetComponent<Ghost>().GetHit();
                Destroy(gameObject);
                break;
            case "Zombie":
                collision.gameObject.GetComponent<Zombie>().GetHit();
                Destroy(gameObject);
                break;
            case "Explosive barrel":
                collision.gameObject.GetComponent<Barrel>().Boom();
                Destroy(gameObject);
                break;
            default:
                break;

        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
