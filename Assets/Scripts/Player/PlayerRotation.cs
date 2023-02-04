using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    private float _rotateSpeed = 0.5f;
    public void Rotate() //Rota al jugador para que mire hacia donde se aprieta el boton de movimiento
    {
        Vector3 currentInput = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        Vector3 targetRotation = transform.localRotation.eulerAngles;

        if (currentInput.x < 0) 
            targetRotation = new Vector3(0, -90, 0);
        else if (currentInput.x > 0) 
            targetRotation = new Vector3(0, 90, 0);
        else if (currentInput.z > 0) 
            targetRotation = new Vector3(0, 0, 0);
        else if (currentInput.z < 0) 
            targetRotation = new Vector3(0, -180, 0);

        transform.localRotation = Quaternion.Lerp(transform.localRotation, Quaternion.Euler(targetRotation), _rotateSpeed);
    }
}
