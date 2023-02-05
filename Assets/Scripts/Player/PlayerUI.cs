using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    private int _healthUIIndex;
    private float _UIUpdateTimer;
    Ray _ray;
    private RaycastHit _hit;
    public void UpdateUI(GameObject[] UIImages, GameObject playerModel, GameObject shieldFill, HealthComponent health, GameObject enemyUI, GameObject enemyUIHealth)
    {
        _UIUpdateTimer -= Time.deltaTime;

        if(_UIUpdateTimer <= 0)
        {
            HealthUI(UIImages, health);
            _UIUpdateTimer = 1f;
        }

        shieldFill.GetComponent<Image>().fillAmount = health.shield / 100;

        EnemyHealthUI(playerModel, enemyUI, enemyUIHealth);
    }


    private void HealthUI(GameObject[] UIImages,  HealthComponent health)
    {
        if (health.health <= 0) _healthUIIndex = 0;
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

    private void EnemyHealthUI(GameObject playerModel, GameObject enemyUI, GameObject enemyUIHealth)
    {
        _ray.origin = transform.position;
        _ray.direction = playerModel.transform.forward;

        if (Physics.Raycast(_ray, out _hit, 2))
        {
            if (_hit.collider.CompareTag("Enemy"))
            {
                enemyUI.gameObject.SetActive(true);
                enemyUIHealth.GetComponent<Image>().fillAmount = (float)_hit.collider.GetComponent<HealthComponent>().health / 100;
            }
        }

        if (_hit.collider == null || !_hit.collider.CompareTag("Enemy"))
        {
            enemyUI.gameObject.SetActive(false);
        }
    }
}
