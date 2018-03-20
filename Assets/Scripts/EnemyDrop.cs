using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDrop : MonoBehaviour {

    [SerializeField]
    GameObject [] powerUpPrefabs;

    void Start () {

    }

    public void Drop () {
        //calcular rango de posibilidades de instanciar un power up
        if (powerUpPrefabs != null)
        {
            int randomNumber = Random.Range(0, 100)+1;

            if (randomNumber >= 50)
            {
                int arrayIndex = Random.Range(0, powerUpPrefabs.Length);
                Instantiate(powerUpPrefabs[arrayIndex], transform.position, transform.rotation);
            }
        }
    }
}
