using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player_Movement : MonoBehaviour
{
    public Camera sceneCamera;
    public Transform myTransform;

    Rigidbody2D myBody;
    [SerializeField] float movement_speed = 10f;
    float speed_limit = 0.6f;
    int bullet = 3;

    Input vertical_input;
    Input horizontal;

    bool movement_Toggle = false;

    private Vector2 mousePosition;

    public Weapon weapon;

    public Image myBulletUI;

    public Sprite threeBullets, twoBullets, oneBullets, noBullets;
    
    // Start is called before the first frame update
    void Start()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    private void FixedUpdate()
    {
        
        if (movement_Toggle == false)
        {
            NormalMovement();
        } else { StrafeMovement(); }
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            movement_Toggle = !movement_Toggle;
        }
        Shooting_Bullets();

    }

    void NormalMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");

        Vector3 my_input = new Vector3(horizontal, vertical_input, 0);
        mousePosition = sceneCamera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 aimDirection = mousePosition - myBody.position;
        float aimangle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;
        myBody.rotation = aimangle;
        if (horizontal != 0 || vertical_input != 0)
        {
            myBody.MovePosition(transform.position + my_input * Time.deltaTime * movement_speed);
            if (horizontal != 0 && vertical_input != 0)
            {
                myBody.MovePosition(transform.position + my_input * Time.deltaTime * movement_speed * speed_limit);
            }
        }

    }

    void StrafeMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical_input = Input.GetAxisRaw("Vertical");
        Vector2 moveUp = new Vector2(horizontal, 0) * movement_speed * Time.deltaTime;
        Vector2 moveRight = new Vector2(0, vertical_input) * movement_speed * Time.deltaTime;
        transform.Translate(moveRight);
        transform.Translate(moveUp);



        // Distance from camera to object.  We need this to get the proper calculation.
        float camDis = sceneCamera.transform.position.y - myTransform.position.y;
        var addAngle = 270;


        // Get the mouse position in world space. Using camDis for the Z axis.
        Vector3 mouse = sceneCamera.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, camDis));

        float direction = Mathf.Atan2(mouse.y - myTransform.position.y, mouse.x - myTransform.position.x);
        float angle = (180 / Mathf.PI) * direction + addAngle;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }

    void Shooting_Bullets()
    {
        if (Input.GetMouseButtonDown(0) && bullet >= 1)
        {
            weapon.Fire();
            bullet--;
        }
        if(bullet == 3)
        {
            myBulletUI.sprite = threeBullets;
        } else if(bullet == 2)
        {
            myBulletUI.sprite = twoBullets;
        }
        else if(bullet == 1)
        {
            myBulletUI.sprite = oneBullets;
        }
        else
        {
            myBulletUI.sprite = noBullets;
        }
    }

}
