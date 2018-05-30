using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    [SerializeField]
    GameObject deadEffect;

    [SerializeField]
    GameObject smokeEffect;

    [SerializeField]
    GameObject fireEffect;

    //[System.NonSerialized]
    public float currentHealth;

    [System.NonSerialized]
    public bool isDieCalled = false;

    [System.NonSerialized]
    public bool isFireEffect = false;

    [System.NonSerialized]
    public bool isSmokeEffect = false;

    public float maxHealth;

    void Start () {
        currentHealth = maxHealth;
	}
	
	void Update () {
		
	}
    public void Damage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
            return;
        }

        //instanciar humo/fuego y se sitúa como hijo del objeto actual

        //Humo
        if (currentHealth < maxHealth && !isSmokeEffect)
        {
           smokeEffect = Instantiate(smokeEffect, transform.position, transform.rotation, transform) as GameObject;
            isSmokeEffect = true;
            smokeEffect.SetActive(true);
        }
        if (currentHealth == maxHealth && isSmokeEffect)
        {
            isSmokeEffect = false;
            smokeEffect.SetActive(false);
        }

        //Fuego
        if (currentHealth < maxHealth / 2 && !isFireEffect)
        {

            if (name.Contains("Pro"))
                fireEffect = Instantiate(fireEffect, transform.position + new Vector3(0, 2, 0), transform.rotation, transform) as GameObject;                
            else
                fireEffect = Instantiate(fireEffect, transform.position + new Vector3(0, 1, 0), transform.rotation, transform) as GameObject;

            fireEffect.SetActive(true);
            isFireEffect = true;
        }
        if (currentHealth > maxHealth / 2 && isFireEffect)
        {
            isFireEffect = false;
            fireEffect.SetActive(false);
        }

        //Actualizamos la barra de vida del Player
        if (gameObject.tag == "TankPlayer")
        {
            //siempre habrá valores entre 0 y 1
            float fillAmountLifeBar = currentHealth / maxHealth;
            GameController.instance.uiController.UpdateLifeBar(fillAmountLifeBar);
        }
    }

    //efecto muerte con delay para que se cumpla el bool ---> TODO: hacerlo con eventos
    public void Die()
    {
        if (deadEffect !=null)
        {
            Instantiate(deadEffect,transform.position,transform.rotation);
        }

        isDieCalled = true;

        EnemyDrop enemyDrop = GetComponent<EnemyDrop>();
        if (enemyDrop != null)
        {
            enemyDrop.Drop();
        }

        Destroy(gameObject, 0.2f); 
    }
}
