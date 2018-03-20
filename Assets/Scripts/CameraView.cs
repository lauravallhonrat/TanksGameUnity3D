using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraView : MonoBehaviour {

    [SerializeField]
     GameObject targetCamara;

    [SerializeField]
    Material alphaColor;
    public Material previousMaterial = null;
    Renderer obstacleRenderer;

    //distancia entre la cámara y el player
     Vector3 offset;

    void Start () {
        //calcular la distancia entre cámapara y player
        offset = transform.localPosition - targetCamara.transform.localPosition;
    }
	
	void Update () {
       // transform.localPosition = targetCamara.transform.localPosition + offset;
        transform.LookAt(targetCamara.transform);

        //RAYCAST
        RaycastHit hit;

        //Direccion: destino - origen
        Vector3 directionRay = targetCamara.transform.position - transform.position;

        //Lanzamos el rayo
        if (Physics.Raycast(transform.position, directionRay, out hit))
        {
            //Obstaculo visual!!!
            if (hit.transform.tag != "TankPlayer" && hit.transform.tag != "EnemyTank")
            {
                if (previousMaterial == null)
                {
                    obstacleRenderer = hit.transform.GetComponent<Renderer>();
                    previousMaterial = obstacleRenderer.material; //Guardamos el material para poder reestablecerlo despues
                    obstacleRenderer.material = alphaColor;//Asignamos el material transparente 
                }

            }
            else //No hay obstaculo visual
            {
                if (previousMaterial != null) //Reestablecemos el material, si es que había algun obstaculo transparente
                {
                    obstacleRenderer.material = previousMaterial;
                    previousMaterial = null;
                }
            }

        }

    }
}
