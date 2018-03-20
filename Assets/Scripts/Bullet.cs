using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {

    [SerializeField]
    GameObject bulletExplosionEffect;

    [SerializeField]
    string targetTag = "TankPlayer";

    [SerializeField]
    float bulletForce = 500; 

    [SerializeField]
    float damage = 1;

	void Start ()
    {
        GetComponent<Rigidbody>().AddRelativeForce(0,0,bulletForce);
	}
	
	void Update ()
    {
        if (transform.position.y < 0)
            Destroy(gameObject);
	}

    //se llama a la función Damage de Health cuando la bala colisiona con el player
    void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);

        if (collision.gameObject.tag == targetTag)
        {
            Health targetHealth = collision.gameObject.GetComponent<Health>();
            targetHealth.Damage(damage);
            Instantiate(bulletExplosionEffect, transform.position, transform.rotation);
        }
    }
}
