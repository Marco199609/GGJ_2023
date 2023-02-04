using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; }

    private float _attackDuration = 0.6f, _attackTimer; //Sacar esto de la duracion de la animation

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
                if (Input.GetMouseButtonDown(0) && !jumping)
                {
                    IsAttacking = true;
                    hit.collider.GetComponent<HealthComponent>().health--;
                    hit.collider.GetComponent<Renderer>().material.color = Color.red;
                }
            }
        }




        //Contador para la animacion
        if (IsAttacking)
        {
            _attackTimer -= Time.deltaTime;
            if(_attackTimer <= 0)
            {
                IsAttacking = false;
                _attackTimer = _attackDuration;
                if(hit.collider != null) hit.collider.GetComponent<Renderer>().material.color = Color.white;
            }
        }
    }
}
