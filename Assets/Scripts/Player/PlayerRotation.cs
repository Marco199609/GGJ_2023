using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class PlayerRotation : MonoBehaviour
{
    private float _rotateSpeed = 0.5f;
    Vector3 targetRotation;
    public void Rotate(GameObject playerModel, GameObject virtualCam) //Rota al jugador para que mire hacia donde se aprieta el boton de movimiento
    {

        if(Input.GetAxisRaw("Vertical") > 0)
            targetRotation = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y, 0);
        else if(Input.GetAxisRaw("Vertical") < 0)
            targetRotation = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y - 180, 0);
        else if(Input.GetAxisRaw("Horizontal") > 0)
            targetRotation = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y + 90, 0);
        else if (Input.GetAxisRaw("Horizontal") < 0)
            targetRotation = new Vector3(0, Camera.main.transform.rotation.eulerAngles.y - 90, 0);

        playerModel.transform.localRotation = Quaternion.Lerp(playerModel.  transform.localRotation, Quaternion.Euler(targetRotation), _rotateSpeed);
    }
}

