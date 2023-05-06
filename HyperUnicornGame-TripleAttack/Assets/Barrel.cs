using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    GameObject explosion;
    public SpriteRenderer barrelSprite;

    public float impactField;
    public LayerMask toHitTarget;

    public void Boom()
    {
        barrelSprite = null;
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, impactField, toHitTarget);
        foreach (Collider2D obj in objects)
        {
            switch (obj.gameObject.tag)
            {
                case "Ghost":
                    obj.gameObject.GetComponent<Ghost>().GetHit();
                    Destroy(gameObject);
                    break;
                case "Zombie":
                    obj.gameObject.GetComponent<Zombie>().GetHit();
                    Destroy(gameObject);
                    break;
                    
            }
        }


        StartCoroutine(DestroyDelay());
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, impactField);
    }
    IEnumerator DestroyDelay()
    {
        yield return new WaitForSeconds(0.3f);
        Destroy(gameObject);
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
