using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class explosion : MonoBehaviour
{
    public float impactField = 5f;
    public LayerMask toHitTarget;

    void Explosion()
    {
        Collider2D[] objects = Physics2D.OverlapCircleAll(transform.position, impactField, toHitTarget);
        foreach(Collider2D obj in objects)
        {
            switch (obj.gameObject.tag)
            {
                case "Ghost":
                    Debug.Log("I hit ghost");
                    break;
            }
        }
    }



    // Start is called before the first frame update
    void Start()
    {
        Explosion();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
