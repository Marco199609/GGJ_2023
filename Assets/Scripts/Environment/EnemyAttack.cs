using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    
    public bool IsAttacking { get; set; }
    private float _attackDuration = 1f, _attackTimer;
    private Ray _ray;

    private void Start()
    {
        _attackTimer = _attackDuration;
    }

    public void Attack()
    {
        var player = FindObjectOfType<PlayerController>();

        if (Vector3.Distance(player.transform.position,transform.position)<2)
        {
            if (player!=null)
            {
                if (!IsAttacking)
                {
                    IsAttacking = true;
                    
                    StartCoroutine("AnimatedHit",player);
                    var healthPlayer = player.GetComponent<HealthComponent>();
                    if (healthPlayer.shield > 0)
                        healthPlayer.shield--;
                    else
                        healthPlayer.health--;
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

    IEnumerator AnimatedHit(PlayerController playerCollider)
    {
        var materials = playerCollider.GetComponentsInChildren<Renderer>();
        for (int i = 0; i < 4; i++)
        {
            foreach (var material in materials)
            {
                material.material.color = Color.red;
            }
            yield return new WaitForSeconds(.08f);    
            foreach (var material in materials)
            {
                material.material.color = Color.white;
            }
            yield return new WaitForSeconds(.08f); 
        }
    }


    private void OnDestroy()
    {
        var materials = FindObjectOfType<PlayerController>().GetComponentsInChildren<Renderer>();
        foreach (var material in materials)
        {
            material.material.color = Color.white;
        }
    }
}
