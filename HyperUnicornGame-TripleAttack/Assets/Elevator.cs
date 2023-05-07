using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elevator : MonoBehaviour
{
    public Collider2D elevatorCollider;
    public SpriteRenderer mySprite;
    public Sprite openElevatorSprite;
    public GameManager manager;

    public GameObject interactUI;

    bool playerInRange = false;
    
    
    // Start is called before the first frame update
    void Start()
    {
        elevatorCollider.isTrigger = false;
    }


    public void OpenElevator()
    {
        mySprite.sprite = openElevatorSprite;
        elevatorCollider.isTrigger = true;

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        playerInRange = true;
        interactUI.SetActive(true);
    }


    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            manager.GameEnd();
            interactUI.SetActive(false);
        }
    }
}
