using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int health;
        
    public float shield;

    private void Update()
    {
        if (!this.CompareTag("Player"))
            if(health <= 0) Destroy(gameObject); //Elimina el objeto si la salud llega a cero

        shield -= Time.deltaTime * 0.5f;

        shield = Mathf.Clamp(shield, 0, 100);

        //La animación de muerte debe activarse por acá
    }
}
