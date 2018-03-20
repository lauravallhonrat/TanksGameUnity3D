using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

    [SerializeField]
    GameObject optionsPanel;

    [SerializeField]
    AudioController audioController;

    // Use this for initialization
    void Start () {
        audioController.PlaySound(Sounds.mainMenuSound);
    }
	
	// Update is called once per frame
	void Update () {
		
	}


    //MAIN MENU PANEL
    public void ShowMainMenuPanel()
    {
        optionsPanel.SetActive(true);
        Cursor.visible = true;
    }

    public void NewGame()
    {
        SceneManager.LoadScene("Level1");
    }


    public void ExitGame()
    {
        Application.Quit();
    }
}
