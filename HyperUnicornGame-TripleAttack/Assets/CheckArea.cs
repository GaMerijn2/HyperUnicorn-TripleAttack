using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckArea : MonoBehaviour
{
    [SerializeField] private Enemy_Movement my_Movement;
    private string detectionTag = "Player";


    private void Awake()
    {
        my_Movement = this.transform.parent.gameObject.GetComponent<Enemy_Movement>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag(detectionTag))
            {
            my_Movement.CheckPlayer = true;
            my_Movement.Player = collision.gameObject.transform;
            Debug.Log("In range");
        }

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        my_Movement.CheckPlayer = false;
        Debug.Log("Went out of range");
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
