using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Pool;

public class ObjectPooling : MonoBehaviour
{
    public Enemy myPrefab;
    private ObjectPool<Enemy> _poolEnemy;

    public string enemyType;

    // Start is called before the first frame update
    void Start()
    {
        enemyType = "ghost";
        //_poolEnemy = new ObjectPool<Enemy>(CreateEnemy,;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    /*private Enemy CreateEnemy()
    {
        Enemy enemy
        // create new object if there is not enough in the pool
        switch (enemyType)
        {
            case "ghost":
                enemy = Instantiate();
                break;
            case "zombie":
                enemy = Instantiate();
                break;

        }

        return enemy;
    }
    */
}
