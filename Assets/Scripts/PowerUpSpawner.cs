using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUpSpawner : MonoBehaviour {

    [SerializeField]
    GameObject powerUpPrefab;

    [SerializeField]
    int numberOfPowerUp = 1;

    void Start()
    {
        for (int i = 0; i < numberOfPowerUp; i++)
        {
            //instanciar power up y posicionar de forma aleatoria
            if (powerUpPrefab != null)
            {
                GameObject instantiatedPowerUp = Instantiate(powerUpPrefab, transform.parent) as GameObject;
                GameController.SetRandomPosition(instantiatedPowerUp.transform);
            }
        }
    }

    void Update()
    {

    }
}
