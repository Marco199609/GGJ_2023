using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int health;

    private void Update()
    {
        if(health <= 0) Destroy(gameObject); //Elimina el objeto si la salud llega a cero

        //La animación de muerte debe activarse por acá
    }
}
