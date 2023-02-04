using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; } //Avisa a los demas scripts que el jugador está atacando

    private float _attackDuration = 0.6f, _attackTimer; //Esta duración depende de la duración de la animación

    private Ray _ray;
    private RaycastHit _hit;
    public void Attack(bool jumping)
    {

        if (Input.GetMouseButtonDown(0) && !jumping && !IsAttacking) //Si está atacando ya, no detecta el click hasta que la animación termine
        {
            IsAttacking = true;

            _ray.origin = transform.position;
            _ray.direction = transform.forward;

            if (Physics.Raycast(_ray, out _hit, 1))
            {
                if (_hit.collider.CompareTag("Enemy"))
                {
                    _hit.collider.GetComponent<HealthComponent>().health--;
                    _hit.collider.GetComponentInChildren<Renderer>().material.color = Color.red; //Cuando está bajo ataque, el enemigo se pone rojo
                }
            }
        }

        //Contador que ataca de acuerdo a la duración de la animación
        if (IsAttacking)
        {
            _attackTimer -= Time.deltaTime;

            if(_attackTimer <= 0)
            {
                IsAttacking = false;
                _attackTimer = _attackDuration; //El contador se resetea

                //Cuando el ataque termina, el enemigo vuelve a su color original
                if (_hit.collider != null && _hit.collider.CompareTag("Enemy")) _hit.collider.GetComponentInChildren<Renderer>().material.color = Color.white; 
            }
        }
    }
}
