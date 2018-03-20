using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelController : MonoBehaviour {

    [Header("Level controller")]

    [SerializeField]
    GameObject[] enemyPrefabs;

    [SerializeField]
    EnemySpawner enemySpawner;

    [SerializeField]
    Transform enemiesParent;

    [SerializeField]
    int currentLevel = 1;

    [SerializeField]
    int endOfGame = 10;



    void Start () {
        
    }
	
	void Update () {
		
	}

    //control de nivel y spawneo
     public void SpawnEnemies()
    {
        if (currentLevel < endOfGame)
        {
            enemySpawner.Spawn(enemyPrefabs[0], currentLevel);
            if (currentLevel % 2 == 0)
            {
                enemySpawner.Spawn(enemyPrefabs[1], currentLevel / 2);
            }
            if (currentLevel % 5 == 0)
            {
                enemySpawner.Spawn(enemyPrefabs[2], currentLevel / 5);
            }
        }
    }

    public void VictoryCondition()
    {
        //condición de victoria
        if (enemiesParent.childCount == 0)
        {
            currentLevel++;
            SpawnEnemies();
            GameController.instance.uiController.DialogController("Level " + currentLevel, 3);

            //Fin del juego???
            if (currentLevel == endOfGame)
                GameController.instance.EndGame();

            //WIN FX
            GameController.instance.audioController.PlaySound(Sounds.winSound);
        }
    }
}
