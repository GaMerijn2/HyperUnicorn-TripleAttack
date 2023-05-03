using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{

    Rigidbody2D rb;
    public Camera cam;
    public Transform my;

    [SerializeField] private float movementSpeed = 5;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    public void FixedUpdate()
    {
        float horizontalInput = Input.GetAxisRaw("Horizontal");
        float verticalInput = Input.GetAxisRaw("Vertical");
        Vector2 moveUp = new Vector2(horizontalInput, 0) * movementSpeed * Time.deltaTime;
        Vector2 moveRight = new Vector2(0, verticalInput) * movementSpeed * Time.deltaTime;
        transform.Translate(moveRight);
        transform.Translate(moveUp);



        // Distance from camera to object.  We need this to get the proper calculation.
        float camDis = cam.transform.position.y - my.position.y;
        var addAngle = 270;


        // Get the mouse position in world space. Using camDis for the Z axis.
        Vector3 mouse = cam.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float direction = Mathf.Atan2(mouse.y - my.position.y, mouse.x - my.position.x);
        float angle = (180 / Mathf.PI) * direction + addAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

    }
        
}
