using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerUps
{
    fireRate,
    healthUp
}

public class PowerUp : MonoBehaviour {

    [SerializeField]
    PowerUps powerUpKind;

    [SerializeField]
    float countDownDuration = 5;


    [SerializeField]
    float value = 10;

    void Awake () {

    }
	
	void Update () {
       
	}

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "TankPlayer")
        {
            Destroy(gameObject);
            //FIRE RATE
            if (powerUpKind == PowerUps.fireRate)
            {
                ShootSystem shootSystem = collision.gameObject.GetComponent<ShootSystem>();
                shootSystem.FireRateUp(value);
                
                //CountDown 
                shootSystem.StartCoroutine(PowerUpCountDown(shootSystem)); 

                //Play FX!
                GameController.instance.audioController.PlaySound(Sounds.powerUpSound);

                return;
            }

            //HEALTH UP
            if (powerUpKind == PowerUps.healthUp)
            {
                Health health = collision.gameObject.GetComponent<Health>();
                health.currentHealth = health.currentHealth + value;
                if (health.currentHealth > health.maxHealth)
                    health.currentHealth = health.maxHealth;

                //Refresh Lifebar
                GameController.instance.uiController.UpdateLifeBar(health.currentHealth / health.maxHealth);

                //Play FX!
                GameController.instance.audioController.PlaySound(Sounds.healthUpSound);
                return;
            }
        }
    }

    //5 seg. CountDown
    public IEnumerator PowerUpCountDown(ShootSystem shootSystem)
    {
        yield return new WaitForSeconds(countDownDuration);
        shootSystem.FireRateDown();
    }
}
