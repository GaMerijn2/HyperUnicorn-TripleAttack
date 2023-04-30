using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Enemy_Movement : MonoBehaviour
{
    NavMeshAgent myEnemy;
    private Vector3 target;

    // Start is called before the first frame update
    void Start()
    {
        myEnemy = GetComponent<NavMeshAgent>();
        myEnemy.updateRotation = false;
        myEnemy.updateUpAxis = false;
    }

    // Update is called once per frame
    void Update()
    {
        HuntingPlayer();
        SetEnemyPosition();
    }

    void HuntingPlayer()
    {
        if (Input.GetMouseButtonDown(0))
        {
            target = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }

    void SetEnemyPosition()
    {
        myEnemy.SetDestination(new Vector3(target.x, target.y, transform.position.z));
    }
}
