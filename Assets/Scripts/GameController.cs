using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {


    [Header("Game Settings")]

    [SerializeField]
    Health playerHealth;

    [SerializeField]
    Transform maincamera;

    [SerializeField]
    GameObject newRecord;

    LevelController levelController;

    [System.NonSerialized]
    public UIController uiController;
   
    [System.NonSerialized]
    public AudioController audioController;

    public static int totalScore;

    //clase singleton
    public static GameController instance;

    bool isGameEnd;

    void Awake()
    {
        //Indicamos que la instancia de GameCOntroller statica, somos nosotros.
        instance = this;
        Time.timeScale = 1;

        //Obtenemos el AudioController de nuestros hijos.
        audioController = GetComponentInChildren<AudioController>();
        levelController = GetComponentInChildren<LevelController>();
        uiController = GetComponentInChildren<UIController>();
        //Instanciamos la primera racha de enemigos
        levelController.SpawnEnemies();

    }

    void Start () {

        uiController.Initialize();
        //MUSIC
        audioController.PlaySound(Sounds.environmentSound);

        //High Score
        // PLayerPrefs nos permite leer y escribir variables en disco. 
        //Has key nos dice si ya existe en disco una variable con ese nombre: "HighScore"
        if (PlayerPrefs.HasKey("HighScore")) 
        {
            uiController.highScoreText.text = "High Score: " + PlayerPrefs.GetInt("HighScore");
           
        }
        Cursor.lockState = CursorLockMode.Locked;
    }
	
	void Update () {



        if (isGameEnd)
            return;

        if (Input.GetKeyDown(KeyCode.Escape))
            Cursor.lockState = CursorLockMode.None;

        //condición de victoria
        levelController.VictoryCondition();
        //condición de derrota
        if (playerHealth.isDieCalled == true)
        {
            EndGame();
        }

        //GOD MODE FOR TESTING - KILL ALL TANKS
        //if (Input.GetKeyUp(KeyCode.K))
        //    foreach (EnemyTank et in FindObjectsOfType<EnemyTank>())
        //        Destroy(et.gameObject);
	}

    //parar juego y posicionar la camara en la raíz de hierarchy
    public void EndGame()
    {
        //si hay endgame desbloqueamos el ratón
        Cursor.lockState = CursorLockMode.None;

        Time.timeScale = 0;
        maincamera.parent = null;
        uiController.ShowEndPanel();
        isGameEnd = true;
        //Nuevo RECORD
        if (totalScore > PlayerPrefs.GetInt("HighScore"))
        {
            uiController.highScoreText.text = "High Score: " + totalScore;
            PlayerPrefs.SetInt("HighScore", totalScore);
            newRecord.SetActive(true);
            
        }
        //FX
        GameController.instance.audioController.StopSound(Sounds.environmentSound);
        GameController.instance.audioController.StopSound(Sounds.tankEngineStopSound);
        GameController.instance.audioController.PlaySound(Sounds.gameOverSound);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void ReloadScene()
    {
        SceneManager.LoadScene("Level1");
    }

    public void BackToMainMenu()
    {
        SceneManager.LoadScene("Main_menu");
    }
    public static void SetRandomPosition(Transform objectToPosition)
    {
        float x;
        float y;
        float z;
        
        x = Random.Range(-45, 45);
        y = 0.5f;
        z = Random.Range(-45, 45);
        objectToPosition.position = new Vector3(x, y, z);
    }

    //incremento de puntuación
    public void AddScore(int scoreToAdd)
    {
        totalScore += scoreToAdd;
        uiController.scoreText.text = string.Format("Score: {0}", totalScore); 
    }

}
