using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootSystem : MonoBehaviour {

    [SerializeField]
    Transform spawnPoint;

    [SerializeField]
    KeyCode shootKey = KeyCode.Space;

    [SerializeField]
    GameObject bulletPrefab;

    [SerializeField]
    float currentFireRate = 0.7f;

    [SerializeField]
    bool autoFire = false;

    float previousFireRate = 0.7f;

    //time counter
    float nextFire = 0;

	void Start () {
        previousFireRate = currentFireRate;
    }
	
	void Update () {
        if ((Input.GetKey(shootKey) || autoFire == true) && Time.time > nextFire) //TODO: con Santi. Pooling: solución al problema de rendimiento de crear y destrir objetos constantemente. 
        {
            Shoot();
            nextFire = Time.time + currentFireRate;
        }
    }

    public void Shoot()
    {
        Instantiate(bulletPrefab, spawnPoint.position, spawnPoint.rotation);
    }

    public void FireRateUp(float fireRateValue)
    {
        currentFireRate = fireRateValue;
    }

    public void FireRateDown()
    {
        currentFireRate = previousFireRate;
    }
}
