using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Sounds
{
    tankEngineStopSound,
    tankEngineSound,
    powerUpSound,
    healthUpSound,
    winSound,
    environmentSound,
    mainMenuSound,
    gameOverSound
}

public class AudioController : MonoBehaviour {

    [Header("Audios")]
    [SerializeField]
    AudioSource tankEngineStopSound;

    [SerializeField]
    AudioSource tankEngineSound;

    [SerializeField]
    AudioSource powerUpSound;

    [SerializeField]
    AudioSource healthUpSound;

    [SerializeField]
    AudioSource winSound;

    [SerializeField]
    AudioSource environmentSound;

    [SerializeField]
    AudioSource mainMenuSound;

    [SerializeField]
    AudioSource gameOverSound;

    void Start () {
		
	}
	
	void Update () {
		
	}

    public void PlaySound (Sounds sound)
    {
        //TANK MOVEMENT
        if (sound == Sounds.tankEngineStopSound)
        {
            tankEngineStopSound.Play();
            tankEngineSound.Pause();
            return;
        }
        if (sound == Sounds.tankEngineSound)
        {
            tankEngineStopSound.Pause();
            tankEngineSound.Play();
            return;
        }

        //POWER UPS
        if (sound == Sounds.powerUpSound)
        {
            powerUpSound.Play();
            return;
        }
        if (sound == Sounds.healthUpSound)
        {
            healthUpSound.Play();
            return;
        }

        //WIN
        if (sound == Sounds.winSound)
        {
            winSound.Play();
            return;
        }

        //ENVIRONMENT
        if (sound == Sounds.environmentSound)
        {
            environmentSound.Play();
            return;
        }

        //MAIN MENU   
        if (sound == Sounds.mainMenuSound)
        {
            mainMenuSound.Play();
            return;
        }
        //WIN   
        if (sound == Sounds.gameOverSound)
        {
            gameOverSound.Play();
            return;
        }

    }

    public void StopSound(Sounds sound)
    {

        //ENVIRONMENT
        if (sound == Sounds.environmentSound)
        {
            environmentSound.Stop();
            return;
        }

        //TANK MOVEMENT
        if (sound == Sounds.tankEngineStopSound)
        {
            tankEngineStopSound.Stop();
            return;
        }

    }
}
