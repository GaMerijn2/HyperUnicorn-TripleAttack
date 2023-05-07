using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBox : MonoBehaviour
{
    private bool playerInRange;
    private bool boxIsOn;
    public GameObject lights;
    public GameObject interact_UI;

    public GameManager manager;

    public bool PowerOn{
        get { return boxIsOn; }
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && playerInRange)
        {
            if (boxIsOn == false)
            {
                // turn powerbox animation on.
                boxIsOn = true;
                lights.SetActive(true);
                Debug.Log("a switch is turned on");
                manager.PowerLevelUp();
                interact_UI.SetActive(false);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if(boxIsOn == false)
            {
                interact_UI.SetActive(true);
            }
            playerInRange = true;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (boxIsOn == false)
            {
                interact_UI.SetActive(false);
            }
            playerInRange = false;
        }
    }
}
