using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerUI : MonoBehaviour
{
    private int _healthUIIndex;
    private float _UIUpdateTimer;
    public void UpdateUI(GameObject[] UIImages, HealthComponent health)
    {
        _UIUpdateTimer -= Time.deltaTime;

        if(_UIUpdateTimer <= 0)
        {
            HealthUI(UIImages, health);
            _UIUpdateTimer = 1f;
        }
    }


    private void HealthUI(GameObject[] UIImages, HealthComponent health)
    {
        if (health.health > 0 && health.health < 20) _healthUIIndex = 1;
        if (health.health >= 20 && health.health < 40) _healthUIIndex = 2;
        if (health.health >= 40 && health.health < 60) _healthUIIndex = 3;
        if (health.health >= 60 && health.health < 80) _healthUIIndex = 4;
        if (health.health >= 80 && health.health < 100) _healthUIIndex = 5;

        for(int i = 0; i < UIImages.Length; i++)
        {
            if(i == _healthUIIndex)
                UIImages[i].gameObject.SetActive(true);
            else
                UIImages[i].gameObject.SetActive(false);
        }
    }
}
