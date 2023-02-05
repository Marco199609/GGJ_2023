using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthPowerup : MonoBehaviour
{
    [SerializeField] private int _healthPowerup;
    [SerializeField] private AudioClip _powerupClip;
    [SerializeField] private AudioSource _audioSource;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            other.GetComponent<HealthComponent>().health += _healthPowerup;
            //_audioSource.PlayOneShot(_powerupClip);
            Destroy(gameObject);
        }
    }
}
