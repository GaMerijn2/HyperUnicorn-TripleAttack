using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Movement : MonoBehaviour
{
    public Camera sceneCamera;


    Rigidbody2D myBody;
    [SerializeField] float movement_speed = 5f;
    float speed_limit = 0.6f;

    Input vertical_input;
    Input horizontal;

    private Vector2 mousePosition;


    
    
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");

        Vector3 my_input = new Vector3(horizontal, vertical_input, 0);
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 aimDirection = mousePosition - myBody.position;
        float aimangle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        myBody.rotation = aimangle;
        if(horizontal != 0 || vertical_input != 0)
        {
            myBody.MovePosition(transform.position + my_input * Time.deltaTime * movement_speed);
            if (horizontal != 0 && vertical_input != 0)
            {
                myBody.MovePosition(transform.position + my_input * Time.deltaTime * movement_speed * speed_limit);
            }
        }

    }

    // Update is called once per frame
    void Update()
    {
       
    }
}
