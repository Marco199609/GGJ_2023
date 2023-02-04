using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    public bool IsAttacking { get; set; }
    private float _attackDuration = 2f, _attackTimer;
    private Ray _ray;

    private void Start()
    {
        _attackTimer = _attackDuration;
    }

    public void Attack()
    {
        RaycastHit hit;
        _ray.origin = transform.position;
        _ray.direction = transform.forward;

        if (Physics.Raycast(_ray, out hit, 1))
        {
            if (hit.collider.GetComponent<PlayerController>()!=null)
            {
                if (!IsAttacking)
                {
                    IsAttacking = true;
                    
                    var playerCollider = hit.collider;
                    StartCoroutine("AnimatedHit",playerCollider);
                }
            }
        }
        
        if (IsAttacking)
        {
            _attackTimer -= Time.deltaTime;

            if(_attackTimer <= 0)
            {
                IsAttacking = false;
                _attackTimer = _attackDuration;
            }
        }
        
        
    }

    IEnumerator AnimatedHit(Collider playerCollider)
    {
        for (int i = 0; i < 4; i++)
        {
            playerCollider.GetComponentInChildren<Renderer>().material.color = Color.red;
            yield return new WaitForSeconds(.08f);    
            playerCollider.GetComponentInChildren<Renderer>().material.color = Color.white;
            yield return new WaitForSeconds(.08f); 
        }
    }


    private void OnDestroy()
    {
        FindObjectOfType<PlayerController>().GetComponentInChildren<Renderer>().material.color = Color.white;
    }
}
