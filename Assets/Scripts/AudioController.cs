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
    mainMenuSound
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

        //MAIN MENU   new
        if (sound == Sounds.mainMenuSound)
        {
            mainMenuSound.Play();
            return;
        }


    }
}
