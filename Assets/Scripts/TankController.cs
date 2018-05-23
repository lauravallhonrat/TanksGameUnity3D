using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankController : MonoBehaviour {

    [SerializeField]
    Transform headTank;

    //[SerializeField]
    //Transform canonTank; 

    [Header("Tank settings")]
    [SerializeField]
    float tankSpeed = 3;

    [SerializeField]
    float tankSpeedRotation = 30;

    [SerializeField]
    float headSpeed = 20;

    [SerializeField]
    float canonSpeed = 10;


    void Start () {
     

        //FX
        GameController.instance.audioController.PlaySound(Sounds.tankEngineStopSound);

    }

    void Update () {

        TankMovement();
        HeadTankRotation();
        TankFX();
    }

    //movimiento y rotación del tanque mediante translate/rotate 
    void TankMovement()
    {
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");
           
        transform.Translate(-Vector3.forward * tankSpeed * verticalInput * Time.deltaTime);
        transform.Rotate(Vector3.up * tankSpeedRotation * horizontalInput * Time.deltaTime);
    }

    //control parte superior del tanque
    void HeadTankRotation()
    {
        float xAxisMouse = Input.GetAxis("Mouse X");
        float yAxisMouse = Input.GetAxis("Mouse Y");

        headTank.Rotate(Vector3.up * headSpeed * xAxisMouse * Time.deltaTime);
       // canonTank.Rotate(-Vector3.right * canonSpeed * yAxisMouse * Time.deltaTime); //invert X axis
    }

    void TankFX()
    {
        if (Input.GetButtonDown("Vertical"))
        {
            GameController.instance.audioController.PlaySound(Sounds.tankEngineSound);
        }
        if (Input.GetButtonUp("Vertical"))
        {
            GameController.instance.audioController.PlaySound(Sounds.tankEngineStopSound);
        }
    }
}
