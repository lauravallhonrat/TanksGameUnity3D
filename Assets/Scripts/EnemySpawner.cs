using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour {
   
    public GameObject enemySpawnTankPrefab;

    [SerializeField]
    Transform enemiesParent;

    [SerializeField]
    int numberOfEnemies = 1;

    [SerializeField]
    bool autoSpawnOnAwake;

    void Awake()
    {
        if (autoSpawnOnAwake)
        {
            Spawn();
        }
    }

    /// <summary>
    /// Espawn de los valores asignados desde el inspector
    /// </summary>
    public void Spawn()
    {
        if (enemySpawnTankPrefab != null)
        {
            for (int i = 1; i <= numberOfEnemies; i++)
            {
                Instantiate(enemySpawnTankPrefab, transform.position, transform.rotation, enemiesParent);
            }
        }
        else
        {
            Debug.LogWarning("enemyPrefab null");
        }
    }

    /// <summary>
    /// Espawn del prefab asignado desde el inspector Unity
    /// </summary>
    public void Spawn(int numberOfEnemies = 1)
    {
        if (enemySpawnTankPrefab !=null)
        {
            for (int i = 1; i <= numberOfEnemies; i++)
            {
                Instantiate(enemySpawnTankPrefab, transform.position, transform.rotation, enemiesParent);
            }
        }
        else
        {
            Debug.LogWarning("enemyPrefab null");
        }
    }

    /// <summary>
    /// Espawneo del prefab 
    /// </summary>
    public void Spawn(GameObject enemyPrefab, int numberOfEnemies = 1)
    {
        if (enemyPrefab != null)
        {
            for (int i = 1; i <= numberOfEnemies; i++)
            {
                Instantiate(enemyPrefab, transform.position, transform.rotation, enemiesParent);
            }
        }
        else
        {
            Debug.LogError("enemyPrefab null");
        }
    }

}
