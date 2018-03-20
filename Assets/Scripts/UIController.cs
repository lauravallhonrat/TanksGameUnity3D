using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour {

    [Header("Life Bar")]


    [SerializeField]
    Image healthBarPlayer;

    [Header("UI")]

    [SerializeField]
    GameObject dialogObject;

    public Text scoreText;

    [SerializeField]
    GameObject endGamePanel;

    public Text highScoreText;

    //Estado inicial del cursor
    [SerializeField]
    bool cursorVisible;

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void Initialize()
    {
        Cursor.visible = cursorVisible;
        dialogObject.SetActive(false);
    }

    public void UpdateLifeBar(float life)
    {
        healthBarPlayer.fillAmount = life;
    }

    //END GAME PANEL
    public void ShowEndPanel()
    {
        endGamePanel.SetActive(true);
        Cursor.visible = true;
    }

    //DIALOG CONTROLLER
    public void DialogController(string text, float time)
    {
        StartCoroutine(DialogActivator(time));
        dialogObject.GetComponentInChildren<Text>().text = text;
    }

    //Control del tiempo que está en pantalla un diálogo
    private IEnumerator DialogActivator(float time)
    {
        dialogObject.SetActive(true);
        yield return new WaitForSeconds(time);
        dialogObject.SetActive(false);
    }
}
