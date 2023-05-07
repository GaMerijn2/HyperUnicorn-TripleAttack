using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spike_Trap : MonoBehaviour
{
    bool triggered;
    bool trapIsActive = false;
    public PowerBox powerBox;
    public Collider2D trapCollider;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(powerBox.PowerOn == true)
        {
            trapCollider.enabled = true;
            // set collider on
            // if trap activated
        }
    }

    public void ActivateTrap()
    {
        trapIsActive = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!trapIsActive)
            return;
        if (triggered)
        {

        } else
        {

        }
  
        Debug.Log("hello");

    }

    IEnumerator SpikesActive()
    {
        yield return new WaitForSeconds(0.5f);
        triggered = true;
        yield return new WaitForSeconds(2f);
        triggered = false;
    }

}
