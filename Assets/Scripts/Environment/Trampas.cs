using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class Trampas : MonoBehaviour
{
    private List<Espinas> espinas = new List<Espinas>();
    private void Start()
    {
        espinas = GetComponentsInChildren<Espinas>().ToList();
    }

    private void OnTriggerEnter(Collider other)
    {
        var player = other.GetComponent<PlayerController>();
        if (player!=null)
        {
            foreach (var espina in espinas)
            {
                espina.ActivateAnimation();
            }
        }
    }
    
    
}
