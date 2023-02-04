using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    public bool IsAttacking { get; private set; }

    private float _attackDuration = 1.6f, _attackTimer; //Sacar esto de la duracion de la animation
    public void Attack(bool jumping)
    {
        if (Input.GetMouseButtonDown(0) && !jumping) IsAttacking = true;

        if(IsAttacking)
        {
            _attackTimer -= Time.deltaTime;
            if(_attackTimer <= 0)
            {
                IsAttacking = false;
                _attackTimer = _attackDuration;
            }
        }
    }
}
