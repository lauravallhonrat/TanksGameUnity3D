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

    [System.NonSerialized]
    public float currentHealth;

    [System.NonSerialized]
    public bool isDieCalled = false;

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
        if (currentHealth < maxHealth && smokeEffect != null)
        {
            Instantiate(smokeEffect,transform.position, transform.rotation,transform);
        }

        //Fuego
        if (currentHealth < maxHealth/2 && fireEffect != null)
        {
            Instantiate(fireEffect, transform.position, transform.rotation, transform);
        }

        //Actualizamos la barra de vida del Player
        if (gameObject.tag == "TankPlayer")
        {
            float life = currentHealth / maxHealth;
            GameController.instance.uiController.UpdateLifeBar(life);
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

        Destroy(gameObject, 0.1f); 
    }
}
