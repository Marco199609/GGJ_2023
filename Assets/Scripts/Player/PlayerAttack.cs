using System;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; } //Avisa a los demas scripts que el jugador est? atacando

    private float _attackDuration = 0.6f, _attackTimer; //Esta duraci?n depende de la duraci?n de la animaci?n

    private Ray _ray;
    private RaycastHit _hit;
    public void Attack(GameObject playerModel, bool jumping, int playerDamage, AudioSource audioSource, AudioClip attackSound)
    {

        if (Input.GetMouseButtonDown(0) && !jumping && !IsAttacking) //Si est? atacando ya, no detecta el click hasta que la animaci?n termine
        {
            IsAttacking = true;

            _ray.origin = transform.position;
            _ray.direction = playerModel.transform.forward;

            if (Physics.Raycast(_ray, out _hit, 2))
            {
                if (_hit.collider.CompareTag("Enemy"))
                {
                    _hit.collider.GetComponent<HealthComponent>().health -= playerDamage;

                    audioSource.PlayOneShot(attackSound);

                    for(int i  = 0; i < _hit.collider.GetComponentInChildren<Renderer>().materials.Length; i++)
                    {
                        _hit.collider.GetComponentInChildren<Renderer>().materials[i].color = Color.red; //Cuando est? bajo ataque, el enemigo se pone rojo
                    } 
                }
            }
        }

        //Contador que ataca de acuerdo a la duraci?n de la animaci?n
        if (IsAttacking)
        {
            _attackTimer -= Time.deltaTime;

            if(_attackTimer <= 0)
            {
                IsAttacking = false;
                _attackTimer = _attackDuration; //El contador se resetea

                //Cuando el ataque termina, el enemigo vuelve a su color original
                if(_hit.collider != null && _hit.collider.CompareTag("Enemy"))
                {
                    for (int i = 0; i < _hit.collider.GetComponentInChildren<Renderer>().materials.Length; i++)
                    {
                        _hit.collider.GetComponentInChildren<Renderer>().materials[i].color = Color.white; //Cuando termina el ataque, el material vuelva a su color original
                    }
                }
            }

            //Reproduce el sonido de ataque a la mitad

            if(_hit.collider != null && _hit.collider.CompareTag("Enemy") && _attackTimer <= _attackDuration / 2)
            {
                if(!audioSource.isPlaying && _attackTimer > ((_attackDuration / 2) - 0.2f))
                    audioSource.PlayOneShot(attackSound);
            }
        }
    }
}
