using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; } //Avisa a los demas scripts que el jugador est� atacando

    private float _attackDuration = 0.6f, _attackTimer; //Esta duraci�n depende de la duraci�n de la animaci�n

    private Ray _ray;
    public void Attack(bool jumping)
    {
        RaycastHit hit;
        _ray.origin = transform.position;
        _ray.direction = transform.forward;

        if (Physics.Raycast(_ray, out hit, 1))
        {
            if (hit.collider.CompareTag("Enemy"))
            {
                if (Input.GetMouseButtonDown(0) && !jumping && !IsAttacking) //Si est� atacando ya, no detecta el click hasta que la animaci�n termine
                {
                    IsAttacking = true;
                    hit.collider.GetComponent<HealthComponent>().health--;
                    hit.collider.GetComponent<Renderer>().material.color = Color.red; //Cuando est� bajo ataque, el enemigo se pone rojo
                }
            }
        }

        //Contador que ataca de acuerdo a la duraci�n de la animaci�n
        if (IsAttacking)
        {
            _attackTimer -= Time.deltaTime;

            if(_attackTimer <= 0)
            {
                IsAttacking = false;
                _attackTimer = _attackDuration; //El contador se resetea
                if(hit.collider != null) hit.collider.GetComponent<Renderer>().material.color = Color.white; //Cuando el ataque termina, el enemigo vuelve a su color original
            }
        }
    }
}
