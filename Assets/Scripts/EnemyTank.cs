using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTank : MonoBehaviour {

    Health health;

    Transform targetPlayerTank;

    [SerializeField]
    float tankSpeed = 5;

    [SerializeField]
    int points = 100;

    void Awake () {
        GameController.SetRandomPosition(transform);
        targetPlayerTank = GameObject.FindGameObjectWithTag("TankPlayer").transform;
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
        if (targetPlayerTank != null)
        {
            //bloquear la posición Y del gameObject 
            Vector3 setPosition = new Vector3(transform.position.x, 0.5f, transform.position.z);
            transform.position = setPosition;

            //miramos hacia el player y avanzamos
            float speedToTarget = tankSpeed * Time.deltaTime;
            transform.LookAt(targetPlayerTank.position);
            transform.Translate(0, 0, speedToTarget);
           // transform.position = Vector3.MoveTowards(transform.position, targetEnemytank.position, speedToTarget);//TODO: cambiar a movimiento hacia Z normal.
        }
    }
}
