using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{
    GameObject enemyObject;
    GameObject child;
    NavMeshAgent myEnemy;
    private Vector3 target;
    private bool checkPlayer = false;
    private Transform player;

    private float timer = 15f;

    public Transform Player { 
        get { return player; }
        set { player = value; }
    }

    public bool CheckPlayer
    {
        get { return checkPlayer; }
        set { checkPlayer = value; }
    }

    // Start is called before the first frame update
    void Start()
    {
        enemyObject = this.gameObject;
        target = this.transform.position;
        child = enemyObject.transform.GetChild(0).gameObject;
        myEnemy = GetComponent<NavMeshAgent>();
        myEnemy.updateRotation = false;
        myEnemy.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
       
        
        

    }

    private void FixedUpdate()
    {
        HuntingPlayer();
        SetEnemyPosition();
        EnemyDirection();
    }


    void HuntingPlayer()
    {
        if (!checkPlayer)
        {
            if(timer >= 6f)
            {
                timer = 7f;
            }
            else
            {
                timer += Time.deltaTime;
            }
        } else if (checkPlayer)
        {
            timer = 0f;
        }
        if (timer <= 5f)
        {
            target = player.position;
        }
    }

    void SetEnemyPosition()
    {
        myEnemy.SetDestination(new Vector3(target.x, target.y, transform.position.z));
        
    }

    // is responsable for the detection box of the enemy
    private void EnemyDirection()
    {
        if (myEnemy.velocity.y > .5f)
        {
            if (myEnemy.velocity.x > .5f)
            {
                child.transform.localEulerAngles = new Vector3(0, 0, 135);
            }
            else if (myEnemy.velocity.x < -.5f)
            {
                child.transform.localEulerAngles = new Vector3(0, 0, 225);
            }
            else
            {
                child.transform.localEulerAngles = new Vector3(0, 0, 180);
            }
        }
        else if (myEnemy.velocity.y < -.5f)
        {
            if (myEnemy.velocity.x > .5f)
            {
                child.transform.localEulerAngles = new Vector3(0, 0, 45);
            }
            else if (myEnemy.velocity.x < -.5f)
            {
                child.transform.localEulerAngles = new Vector3(0, 0, 315);
            }
            else
            {
                child.transform.localEulerAngles = new Vector3(0, 0, 0);
            }
        }
        else if (myEnemy.velocity.x > .5f)
        {
            child.transform.localEulerAngles = new Vector3(0, 0, 90);
        }
        else if (myEnemy.velocity.x < -.5f)
        {
            child.transform.localEulerAngles = new Vector3(0, 0, 270);
        }
    }
}
