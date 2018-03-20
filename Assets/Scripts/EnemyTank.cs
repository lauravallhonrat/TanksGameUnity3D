using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour {

    Health health;

    Transform targetEnemytank;

    [SerializeField]
    float tankSpeed = 5;

    [SerializeField]
    int points = 100;

    void Awake () {
        GameController.SetRandomPosition(transform);
        targetEnemytank = GameObject.FindGameObjectWithTag("TankPlayer").transform;
        health = gameObject.GetComponent<Health>();
    }
	
	void Update () {
        EnemyTankMovement();

        //TODO: crear evento de muerte
        if (health.isDieCalled == true)
        {
            FindObjectOfType<GameController>().AddScore (points);
            Destroy(gameObject);            
        }
    }

    void EnemyTankMovement()
    {
        //movimiento tanque enemigo hacia el player
        if (targetEnemytank != null)
        {
            float speedToTarget = tankSpeed * Time.deltaTime;
            transform.LookAt(targetEnemytank.position);
            transform.position = Vector3.MoveTowards(transform.position, targetEnemytank.position, speedToTarget);//TODO: cambiar a movimiento hacia Z normal.
        }
    }
}
