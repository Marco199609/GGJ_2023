using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Espinas : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        
        var player = other.GetComponent<PlayerController>();
        if (player!=null)
        {
            StartCoroutine("AnimatedHit",player);
            var health = player.GetComponent<HealthComponent>();
            if (health.shield > 0)
                health.shield--;
            else
                health.health--;
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
